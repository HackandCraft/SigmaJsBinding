
module Views.Timeline

open Feliz.Bulma
open Feliz
open App

let element (trips: TripDetails list) = 
  
    Feliz.Bulma.Timeline.timeline [
        timeline.isRtl
        prop.children [
            Timeline.header [ Bulma.tag [ color.isPrimary; tag.isMedium; prop.text "Current" ] ]
            trips 
            |> List.mapi ( fun i t ->
                Timeline.item [
                    match t.Type with
                    | "Distributor -> Demand" -> color.isDanger
                    | "Supply -> Distributor" -> color.isWarning
                    | other -> color.isInfo
                    prop.children [
                        Timeline.marker [
                            color.isWarning
                            marker.isIcon
                            prop.children [ Html.i [ prop.className "fas fa-exclamation" ] ]
                        ]
                        Timeline.content [
                            Timeline.content.header $"Trip ({t.Payload})"
                            Timeline.content.content t.Type
                        ]
                    ]
                ]
            )
            |> Timeline.content
                
            Timeline.header [ Bulma.tag [ color.isPrimary; tag.isMedium; prop.text "Start" ] ]
        ]
    ]
