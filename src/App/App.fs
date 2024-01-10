module Dashboard

open Sutil
open Sutil.CoreElements
open Styles
open Views
open App
open Model
open Data.HarryExample

type PlaceMessage =
    | SelectCountries of countries: string list
    | DisplayTrip of TripDetails
    | Click of nodeKey: string
    
type Message =
    | Graph of GraphMessage
    | Stopwatch of StopwatchMessage
    | Place of PlaceMessage

module Elmish =

    let init () : AppModel<HarryData>*Cmd<Message> = 

        let stopwatchModel, stopwatchCmd = StopwatchElmish.init ()

        let graphModel, graphCmd = 
            Data.HarryExample.DataSet 
            |> Data.HarryExample.HarryData.toGraphData
            |> GraphElmish.init

        let byCountry = Places.data |> List.groupBy (fun x -> x.Country)

        let cities =
            {
                All = Places.data
                ByCountry = byCountry
                SelectedCountries = byCountry |> List.map fst |> List.sort
                LastTrips = []
            }

        { GraphState = graphModel; StopwatchState = stopwatchModel; PlacesState = cities }, 
            Cmd.batch 
                [
                    stopwatchCmd |> Cmd.map Stopwatch
                    graphCmd |> Cmd.map Graph
                ]

    let update (msg: Message) (model: AppModel<HarryData>) : AppModel<HarryData>*Cmd<Message> =
        // todo: process submessages my intercepting updates, not Cmd's
        match msg with
        | Graph msg ->
            let state, cmd = GraphElmish.update msg model.GraphState

            { model with GraphState = state }, 
               
                Cmd.map 
                    (function
                        | Edge name -> Place (DisplayTrip name) 
                        | Processed -> Stopwatch StopwatchMessage.Stop
                        | other -> Graph other) 
                    cmd

        | Stopwatch msg -> 
            let state, cmd = StopwatchElmish.update msg model.StopwatchState
            { model with StopwatchState = state }, 
                Cmd.batch [
                    cmd 
                    |> Cmd.map (function
                    | NotifyStop -> Graph Dijkstra
                    | Second -> Graph Action
                    | other -> Stopwatch other)
                ]

        | Place (SelectCountries countries) ->
            { model with PlacesState.SelectedCountries = countries }, Cmd.none

        | Place (DisplayTrip trip) ->
            let next = (trip :: model.PlacesState.LastTrips) 
            { model with PlacesState.LastTrips = next |> List.take (min next.Length 5) }, Cmd.none

        | Place (Click name) ->
            model, Cmd.ofMsg (Graph (SetNode name))

    let view() =

        let (model: IStore<AppModel<HarryData>>), dispatch = () |> Store.makeElmish init update ignore

        let reactElement (reactEl: Fable.React.ReactElement) =
            host <| fun el -> Feliz.ReactDOM.render (reactEl, el)

        let tags = 
            (fun countries -> dispatch (Place (SelectCountries countries)))
            |> TagsInput.element2 model.Value.PlacesState.SelectedCountries 
            |> reactElement 
    
        Html.div [
            Attr.classes [bm.columns;bm.``is-centered``]
            disposeOnUnmount [ model ]

            fragment [
            
                Html.button [
                    Attr.text $"{model.Value.GraphState.Data.nodes[0].key}"
                    Ev.onClick (fun _ -> dispatch ($"{model.Value.GraphState.Data.nodes[0].key}" |> Click |> Place))
                ]
                Html.div [
                    Attr.classes [ 
                        bm.column
                        bm.``p-5``
                        bm.``is-centered``
                    ]
                    StopwatchElmish.view model (Stopwatch >> dispatch)

                    Html.div [
                        Attr.className bm.columns
                    ]
                    Html.span $"Filter by country (TODO):"
                    Html.div [ tags ]
                ]
                Html.div [
                    Attr.classes [bm.column ; bm.``is-three-fifths``] 
                    GraphElmish.view (model |> Store.map _.GraphState) (Graph >> dispatch)
                ]
                Html.div [
                    Attr.className bm.column 
                    Bind.el(model, fun model -> Views.Timeline.element (model.PlacesState.LastTrips) |> reactElement)
                ]
            ]
        ]

Elmish.view() |> Program.mount
