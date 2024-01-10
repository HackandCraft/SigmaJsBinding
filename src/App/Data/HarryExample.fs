module Data.HarryExample

open Fable.Core
open SigmaDSL

type Type =
    | Distributor
    | Demand
    | Supply

type HarryData =
    {
        date : string
        from : int
        fromGeography : string
        fromType : string
        ``to`` : int
        toGeography : string
        toType : string
        quantity : int

    }

[<Import("data","./Harry.js")>]
let DataSet : HarryData [] = jsNative

module HarryData =

    let places = Places.data 

    let toGraphData (data : HarryData []) =

        let from = data |> Array.map (fun x -> {| Name = x.fromGeography; Key = x.from |}) |> Array.distinct
        let to' = data |> Array.map (fun x -> {| Name = x.toGeography; Key = x.``to`` |}) |> Array.distinct
        let nodeIndexes = [ from; to'] |> Array.concat |> Array.distinct

        let nodes =
            nodeIndexes |> Array.filter ( fun x -> x.Name <> "Globally") |> Array.mapi ( fun i data -> 
                let angle = (float i * 2. * System.Math.PI) / (float nodeIndexes.Length)
                let color = float i / float nodeIndexes.Length |> Views.Colors.Palette.Viridis.color

                let city = places |> List.tryFind ( fun x -> x.Name = data.Name)
     
                let x = 180. * System.Math.Cos(angle) //for circular layout
                let y = 180. * System.Math.Sin(angle) //for circular layout

                { 
                    key = float data.Key
                    attributes = 
                        NodeDisplayData.create(
                            x,
                            y, 
                            8,
                            color,
                            Some data.Name
                        )
                }
            )

        let edges =
            data
            |> Array.filter ( fun x -> x.fromGeography <> "Globally" && x.toGeography <> "Globally" )
            |> Array.mapi ( fun i dt -> 
                {
                    key = i
                    source = nodes |> Array.find ( fun x -> x.key = dt.from) |> _.key
                    target = nodes |> Array.find ( fun x -> x.key = dt.``to``) |> _.key
                    attributes = EdgeDisplayData.create(dt.quantity, "#ff00ff")
                    payload = dt
                    ``type`` = "arrow"
                }
            )

        {
            nodes = nodes
            edges = edges
        }