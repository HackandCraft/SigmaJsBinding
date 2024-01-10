namespace App

open System.Collections.Generic

open Fable.Core.JS

open SigmaDSL
open SigmaBaseTypes
open GraphologyTypes

[<Measure>] type milion

type Longitude = float
type Latitude = float

type Degree = { name: string; degree: float }

type City =
    {
        Name: string
        Country: string
        Location: Longitude * Latitude
        Population: float<milion>
    }

type TripDetails =
    {
        Type: string
        From: string
        To: string
        Payload: string
    }

// app uses sub-elmish mini-apps

module Model =

    type Places = 
        {
            ByCountry: (string * City list) list 
            All: City list
            SelectedCountries: string list
            LastTrips: TripDetails list
        }

    type Stopwatch = 
        {
            Elapsed: float
            StartedAt: System.DateTime
            IsRunning: bool
            Seconds: int
            CancelInterval: unit -> unit
        }

    type GraphState<'Payload> = 
        {
            SearchQuery: string
            HoveredNode: obj option
            SelectedNode: string option
            Suggestions: Set<string> option
            HoveredNeighbors: HashSet<string> option
            Graph: AbstractGraph<NodeDisplayData, EdgeDisplayData> option
            Renderer: Sigma.Sigma<AbstractGraph> option
            Data: GraphDataset<'Payload> 
            Stats: Degree
            ProcessingFinished: bool
        }

    type AppModel<'Payload>  = 
        { 
            GraphState: GraphState<'Payload> 
            StopwatchState: Stopwatch
            PlacesState: Places 
        }