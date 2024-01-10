namespace App

open System

open Sutil
open Sutil.DomHelpers
open Sutil.CoreElements
open Styles
open Model
open Data.HarryExample

type StopwatchMessage =
    | Start
    | Stop
    | NotifyStop
    | Reset
    | Tick
    | Second
    | Cancel of (unit -> unit)

module StopwatchElmish =
    let now() = DateTime.Now
    let time = Store.make DateTime.Now
    let updateTime() = Store.set time DateTime.Now

    let init() =
        {
            Elapsed = 0.0; StartedAt = now(); Seconds = 0;  IsRunning = false; CancelInterval = ignore
        }, Cmd.none

    let nextTick dispatch = rafu (fun _ -> dispatch Tick)

    let nextSecond dispatch =
        interval ( fun _ -> dispatch Second ) 1000
        |> Cancel
        |> dispatch

    let update (msg: StopwatchMessage) (model: Stopwatch) =
        match msg with
        | Start ->
            { model with StartedAt = now(); IsRunning = true },
                Cmd.batch 
                    [
                        Cmd.ofEffect nextTick
                        Cmd.ofEffect nextSecond
                    ]

        | Stop ->
            model.CancelInterval()
            { model with IsRunning = false }, Cmd.ofMsg NotifyStop

        | Reset ->
            init()

        | Tick ->
            if model.IsRunning then
                let t = now()
                let sinceStartMs = (t - model.StartedAt).TotalMilliseconds
                { model with Elapsed = model.Elapsed + sinceStartMs; StartedAt = t },
                    Cmd.ofEffect nextTick
            else
                model, Cmd.none
        | Cancel cancel -> 
            { model with CancelInterval = cancel }, Cmd.none

        | Second ->
            { model with Seconds = model.Seconds + 1 }, Cmd.none
        | NotifyStop ->
            model, Cmd.none

    let view (model: IStore<AppModel<HarryData>>) (dispatch: StopwatchMessage -> unit) = 
       
        Html.div [
            disposeOnUnmount [ model ]
            Attr.classes [ 
                bm.column
                bm.``is-centered``
            ]
            Bind.el(model, fun model -> model.StopwatchState.Elapsed/1000. |> sprintf "Elapsed: %0.3f" |> Html.div)
            Html.button [
                Attr.classes [bm.button; bm.``is-black``; bm.``m-5``]   
                text "Start"
                Ev.onClick (fun _ -> dispatch Start)
            ]
            Html.button [
                Attr.classes [bm.button; bm.``is-primary``; bm.``m-5``]
                text "Stop"
                Ev.onClick (fun _ -> dispatch Stop)
            ]
        ]
        