module Views.NodeList

open Sutil
open Sutil.Bulma
open App
open App.Model
open Data.HarryExample

let element (model: System.IObservable<GraphState<HarryData>>) = 

    Html.div [
        Bind.el(model, fun m -> bulma.field.div  $"Max degree: {m.Stats.name} ({m.Stats.degree})")
        Bind.el(model, fun m -> if m.Graph.IsNone then Html.none else bulma.field.div  [prop.text $"Processed items ({m.Graph.Value.edges().Count}/{m.Data.edges.Length})"])
        Bind.el(model, fun m -> if m.Graph.IsNone then Html.none else bulma.field.div  $"Finished: {m.ProcessingFinished}")
        bulma.field.div [
            prop.id "search"
                
            bulma.label "Go to port:"
            bulma.control.div [
                bulma.input.text [
                    prop.typeSearch
                    prop.id "search-input"
                    prop.custom ("list", "suggestions")
                    prop.placeholder "Try searching for a node..."
                ]
                Html.datalist [
                    prop.id "suggestions"
                ]
            ]
        ]
        Html.div [
            prop.id "sigma-container"

            Attr.style [
                Css.height 600
                Css.minWidth 1000
            ]   
        ]
    ]
