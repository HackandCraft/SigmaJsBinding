// ts2fable 0.9.0
module rec SigmaCamera

open Fable.Core

open SigmaBaseTypes

#nowarn "3390" // disable warnings for invalid XML comments

type [<AllowNullLiteral>] IExports =
    /// <summary>Camera class</summary>
    abstract Camera: CameraStatic

/// Event types.
type [<AllowNullLiteral>] CameraEvents =
    abstract updated: state: CameraState -> unit

/// <summary>Camera class</summary>
type [<AllowNullLiteral>] Camera =
    inherit TypedEventEmitter<CameraEvents>
    inherit CameraState
    abstract x: float with get, set
    abstract y: float with get, set
    abstract angle: float with get, set
    abstract ratio: float with get, set
    abstract minRatio: float option with get, set
    abstract maxRatio: float option with get, set
    abstract animationCallback: (unit -> unit) option with get, set
    /// <summary>Method used to enable the camera.</summary>
    /// <returns />
    abstract enable: unit -> Camera
    /// <summary>Method used to disable the camera.</summary>
    /// <returns />
    abstract disable: unit -> Camera
    /// <summary>Method used to retrieve the camera's current state.</summary>
    /// <returns />
    abstract getState: unit -> CameraState
    /// <summary>Method used to check whether the camera has the given state.</summary>
    /// <returns />
    abstract hasState: state: CameraState -> bool
    /// <summary>Method used to retrieve the camera's previous state.</summary>
    /// <returns />
    abstract getPreviousState: unit -> CameraState option
    /// <summary>Method used to check minRatio and maxRatio values.</summary>
    /// <param name="ratio" />
    /// <returns />
    abstract getBoundedRatio: ratio: float -> float
    /// <summary>Method used to check various things to return a legit state candidate.</summary>
    /// <param name="state" />
    /// <returns />
    abstract validateState: state: obj -> obj
    /// <summary>Method used to check whether the camera is currently being animated.</summary>
    /// <returns />
    abstract isAnimated: unit -> bool
    /// <summary>Method used to set the camera's state.</summary>
    /// <param name="state">New state.</param>
    /// <returns />
    abstract setState: state: obj -> Camera
    /// <summary>Method used to update the camera's state using a function.</summary>
    /// <param name="updater">
    /// Updated function taking current state and
    ///   returning next state.
    /// </param>
    /// <returns />
    abstract updateState: updater: (CameraState -> obj) -> Camera
    /// <summary>Method used to animate the camera.</summary>
    /// <param name="state">State to reach eventually.</param>
    /// <param name="opts">Options:</param>
    /// <param name="duration">Duration of the animation.</param>
    /// <param name="">=&gt; number}   easing   - Easing function or name of an existing one</param>
    /// <param name="callback">Callback</param>
    abstract animate: state: obj * ?opts: obj * ?callback: (unit -> unit) -> unit
    /// <summary>Method used to zoom the camera.</summary>
    /// <param name="factorOrOptions">Factor or options.</param>
    /// <returns />
    abstract animatedZoom: ?factorOrOptions: U2<float, obj> -> unit
    /// <summary>Method used to unzoom the camera.</summary>
    /// <param name="factorOrOptions">Factor or options.</param>
    abstract animatedUnzoom: ?factorOrOptions: U2<float, obj> -> unit
    /// <summary>Method used to reset the camera.</summary>
    /// <param name="options">Options.</param>
    abstract animatedReset: ?options: obj -> unit
    /// <summary>Returns a new Camera instance, with the same state as the current camera.</summary>
    /// <returns />
    abstract copy: unit -> Camera

/// <summary>Camera class</summary>
type [<AllowNullLiteral>] CameraStatic =
    [<EmitConstructor>] abstract Create: unit -> Camera
    /// <summary>Static method used to create a Camera object with a given state.</summary>
    /// <param name="state" />
    /// <returns />
    abstract from: state: CameraState -> Camera