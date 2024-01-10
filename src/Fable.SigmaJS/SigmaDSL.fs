(*
    Hides Graphology/Sigma internals
    and make types more suitable to the addressed domain
*)

//TODO: move type fields to PascalCase, decide the lib first (Thoth.Json or STJ)

module SigmaDSL

open Fable.Core
open Fable.Core.JsInterop
open GraphologyTypes
open SigmaBaseTypes

[<Import("Sigma", "sigma")>]
let Sigma: Sigma.SigmaStatic = jsNative

[<ImportDefault("graphology")>]
let Graphology: AbstractGraphStatic = jsNative

let findPlace (graph: AbstractGraph<NodeDisplayData, EdgeDisplayData>) (city: string) =
    graph.findNode !!(fun (node: string) -> 
        let attr = graph.getNodeAttributes node
        attr.Item "label" = Some city
    )

let findMaxDegree(graph: AbstractGraph<NodeDisplayData, EdgeDisplayData>) =
    let mapper (node: string) =
        let attr = graph.getNodeAttributes node
        let label = attr.label
        let degree = graph.degree node
        {| name = string label.Value; degree = degree |}

    //TODO: how to use NodeMapper from the binding rather than !! 
    let all = graph.mapNodes !!mapper
    all |> Seq.maxBy (fun x -> x?degree)

let filter(graph: AbstractGraph<NodeDisplayData, EdgeDisplayData>) =
    !!(fun (node: string) ->
        let t = JS.parseFloat node  
        t > 89
    )|> graph.filterNodes

type EdgeLine =
    | Arrow
    | Line

let private kvl xs = JsInterop.keyValueList CaseRules.LowerFirst xs

type Node =
    {
        key : float
        attributes : NodeDisplayData
    }

type Edge<'Payload> = 
    {  
        key : int
        source : float
        target : float
        ``type`` : string
        attributes : EdgeDisplayData
        payload : 'Payload
    }

type GraphDataset<'Payload> =
    {
        nodes : Node []
        edges : Edge<'Payload> []
    }

module NodeDisplayData =
    let create(x,y,size,color,label): NodeDisplayData =
        let node = createEmpty<NodeDisplayData> 
        node.x <- x
        node.y <- y
        node.size <- size
        node.color <- color
        node.label <- label
        node

module EdgeDisplayData =
    let create(size,color): EdgeDisplayData =
        let edge = jsOptions<EdgeDisplayData>(ignore)
        edge.color <- color
        edge.size <- size
        edge

    let update(edge: EdgeDisplayData, size, color,label) =
        edge.color <- color
        edge.size <- size
        edge.label <- label
        edge.``type`` <- $"{EdgeLine.Arrow}".ToLower()
        edge