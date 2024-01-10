namespace App

open System
open Sutil
open Sutil.DomHelpers

open Fable.Core
open Fable.Core.JsInterop

open Model
open GraphologyTypes
open SigmaDSL
open Sigma
open SigmaBaseTypes
open Data.HarryExample
open Views.Colors
open SigmaSettings


type GraphMessage =
    | Setup
    | RegisterCommands
    | Refresh
    | Action
    | Hover of node: obj
    | Edge of TripDetails
    | SetNode of name: string
    | Processed
    | Dijkstra

type Payload = HarryData

module GraphState =
    let init<'Source> (dataset: GraphDataset<Payload>) =
        {
            SearchQuery = ""
            HoveredNode = None
            SelectedNode = None
            Suggestions = None
            HoveredNeighbors = None
            Graph = None
            Renderer = None
            Data = dataset
            Stats = { name = "N/A"; degree = 0.0 }
            ProcessingFinished = false
        }

module GraphElmish =
    let mutable hm: obj option = None

    let setInput (searchInput: Browser.Types.HTMLInputElement) (query:string) (model: GraphState<Payload>) =
        if (searchInput.value <> query) then
            searchInput.value <- query
   
        let suggestions = 
            model.Graph.Value.nodes() 
            |> Seq.map (fun node -> {|id = node; label = model.Graph.Value.getNodeAttribute(node,KeyOf<NodeDisplayData>.Key "label").ToString() |})
            |> Seq.toArray
            |> Array.filter ( fun node -> query.ToLower() |> node.label.ToLower().Contains)

        let best = suggestions[0]
        let nodePosition = model.Renderer.Value.getNodeDisplayData(best.id)
        let camera = model.Renderer.Value.getCamera()
        
        camera.animate(nodePosition, {| duration = 500 |})

    let setupSearchQuery (model: GraphState<Payload>)  =  
        let searchInput = Browser.Dom.document.getElementById "search-input" :?> Browser.Types.HTMLInputElement
        searchInput.addEventListener("input", fun _ -> setInput searchInput searchInput.value model)
        searchInput.addEventListener("blur", fun _ -> setInput searchInput "" model)

    let enterNode (renderer: Sigma.Sigma<AbstractGraph>) =

        let sub dispatch = renderer.on(KeyOf<SigmaEvents>.Key "enterNode", fun (evt: SigmaNodeEventPayload) -> dispatch (Hover evt.node)) |> ignore

        Cmd.ofEffect sub

    let leaveNode (renderer: Sigma.Sigma<AbstractGraph>) =

        let sub dispatch =

            renderer.on( KeyOf<SigmaEvents>.Key "leaveNode", fun (evt: SigmaNodeEventPayload) -> 
              dispatch (Hover JS.undefined)
            ) |> ignore
           
        Cmd.ofEffect sub

    let wait (time: int) (msg: GraphMessage) =
        let sub dispatch = 
            let f () = dispatch msg
            let cancel = timeout f time
            ()
        Cmd.ofEffect sub 

    let init (data: GraphDataset<HarryData>) =   
        GraphState.init data, wait 2000 Setup

    let update (msg: GraphMessage) (model: GraphState<HarryData> ) = 

        match msg with 
        | Action -> 
            let uuid = System.Guid.NewGuid().ToString()
          
            let frame = model.Graph.Value.edges().Count

            if frame >= model.Data.edges.Length then 
                model, Cmd.ofMsg Processed
            else
                let edge = model.Data.edges.[frame]
                let maxQuantity = model.Data.edges |> Array.maxBy _.payload.quantity //this should be done once on init
                let rank = float edge.payload.quantity / float maxQuantity.payload.quantity
                let palette = 
                
                    match edge.payload.fromType with
                    | "Supply" -> Palette.Greens
                    | "Distributor" -> Palette.RedToGreen
                    | other -> Palette.Viridis
    
                let label = $"{edge.payload.fromGeography} - ({edge.payload.quantity}) -> {edge.payload.toGeography}"
                let attr = { edge with attributes = EdgeDisplayData.update(edge.attributes, rank * 10., palette.color rank, Some label)}
                let desciption = { From = edge.payload.fromGeography; To = edge.payload.toGeography; Type = $"{edge.payload.fromGeography} -{edge.payload.fromType}({edge.payload.quantity})-> {edge.payload.toGeography}"; Payload = string frame }
            
                let _ = model.Graph.Value.addEdgeWithKey(uuid, edge.source, edge.target, attr.attributes)

                let stats = findMaxDegree model.Graph.Value
                let tianjin = findPlace model.Graph.Value "Tianjin" 
                let degree = model.Graph.Value.degree tianjin

                { model with Graph = model.Graph; Stats = stats}, Cmd.batch [Cmd.ofMsg Refresh; Cmd.ofMsg (Edge desciption)]

        | RegisterCommands ->  
            setupSearchQuery model
            model, 
                Cmd.batch [
                    enterNode model.Renderer.Value
                    leaveNode model.Renderer.Value
                ]
        | Dijkstra -> 
            JS.debugger()
            let Dijkstra = Dijkstra.export'.singleSource(model.Graph.Value, "27")
            { model with ProcessingFinished = true }, Cmd.none
        | Processed ->
            model, Cmd.none
        | Refresh -> 
         
            let t = model.Renderer.Value.refresh()
            { model with  Renderer = Some t }, Cmd.none 

        | Setup -> 
       
            let container = Browser.Dom.document.getElementById "sigma-container"
            let searchSuggestions = Browser.Dom.document.getElementById "suggestions"
            let graph: AbstractGraph<NodeDisplayData, EdgeDisplayData> = Graphology.Create()

            graph.import { model.Data with edges = [||] } |> ignore

            let settings = 
                jsOptions<Settings>( fun settings ->
                    settings.nodeReducer <- !!(fun node -> 
                            let test = graph.getNodeAttributes node
                            if hm.IsSome && hm.Value = node then
                                test.color <- "#ffff00"
                            test)
                    settings.renderEdgeLabels <- true

                )
            let renderer = Sigma.Create(graph, container, settings)
            let renderer = renderer.refresh()

            let raw = graph.nodes() |> Seq.map ( fun node -> $"""<option value="{graph.getNodeAttribute(node, KeyOf<NodeDisplayData>.Key  "label")}"></option>""") |> Utils.join "\n"
            searchSuggestions.innerHTML <-  raw
            

            { model with Graph = Some graph; Renderer = Some renderer}, Cmd.ofMsg RegisterCommands
        | Hover node -> 
            match node with
            | null -> 

                { model with HoveredNode = None; HoveredNeighbors = None }, Cmd.none
            | _->

                hm <- Some node
                { model with HoveredNode = Some node}, Cmd.ofMsg Refresh
        | Edge _ 
        | SetNode _ -> 
            model, Cmd.none

    let view (model: System.IObservable<GraphState<HarryData>>) (dispatch: GraphMessage -> unit) = 
        Views.NodeList.element model