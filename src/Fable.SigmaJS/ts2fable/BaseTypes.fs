// ts2fable 0.9.0
module rec SigmaBaseTypes
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open GraphologyTypes

//[<Erase>] type KeyOf<'T> = Key of string

type Array<'T> = System.Collections.Generic.IList<'T>
type Record<'A, 'B> = JsNative
type IterableIterator<'A> = JsNative
type Omit<'A, 'B> = JsNative
type Parameters<'A> = JsNative
type EventEmitter = obj // Events.EventEmitter


type [<AllowNullLiteral>] IExports =
    abstract TypedEventEmitter: TypedEventEmitterStatic

/// Util type to represent maps of typed elements, but implemented with
/// JavaScript objects.
type PlainObject =
    PlainObject<obj option>

/// Util type to represent maps of typed elements, but implemented with
/// JavaScript objects.
type [<AllowNullLiteral>] PlainObject<'T> =
    [<EmitIndexer>] abstract Item: k: string -> 'T with get, set

/// Returns a type similar to T, but with the K set of properties of the type
/// T *required*, and the rest optional.
type [<AllowNullLiteral>] PartialButFor<'T> =
    interface end

type NonEmptyArray<'T> =
    'T * obj

type [<AllowNullLiteral>] Coordinates =
    abstract x: float with get, set
    abstract y: float with get, set

type [<AllowNullLiteral>] CameraState =
    inherit Coordinates
    abstract angle: float with get, set
    abstract ratio: float with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] MouseInteraction =
    | Click
    | DoubleClick
    | RightClick
    | Wheel
    | Down

type [<AllowNullLiteral>] MouseCoords =
    inherit Coordinates
    abstract sigmaDefaultPrevented: bool with get, set
    abstract preventSigmaDefault: unit -> unit
    abstract original: MouseEvent with get, set

type [<AllowNullLiteral>] WheelCoords =
    inherit MouseCoords
    abstract delta: float with get, set

type [<AllowNullLiteral>] TouchCoords =
    abstract touches: ResizeArray<Coordinates> with get, set
    abstract original: TouchEvent with get, set

type [<AllowNullLiteral>] Dimensions =
    abstract width: float with get, set
    abstract height: float with get, set

type Extent =
    float * float

type [<AllowNullLiteral>] DisplayData =
    abstract label: string option with get, set
    abstract size: float with get, set
    abstract color: string with get, set
    abstract hidden: bool with get, set
    abstract forceLabel: bool with get, set
    abstract zIndex: float with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] NodeDisplayData =
    inherit Coordinates
    inherit DisplayData
    inherit GraphologyTypes.Attributes //added
    abstract highlighted: bool with get, set

type [<AllowNullLiteral>] EdgeDisplayData =
    inherit DisplayData
    inherit GraphologyTypes.Attributes

type [<AllowNullLiteral>] CoordinateConversionOverride =
    abstract cameraState: CameraState option with get, set
    abstract matrix: Float32Array option with get, set
    abstract viewportDimensions: Dimensions option with get, set
    abstract graphDimensions: Dimensions option with get, set
    abstract padding: float option with get, set

type [<AllowNullLiteral>] RenderParams =
    abstract width: float with get, set
    abstract height: float with get, set
    abstract sizeRatio: float with get, set
    abstract zoomRatio: float with get, set
    abstract pixelRatio: float with get, set
    abstract correctionRatio: float with get, set
    abstract matrix: Float32Array with get, set
    abstract downSizingRatio: float with get, set
    abstract downSizedSizeRatio: float with get, set

/// Custom event emitter types.
type [<AllowNullLiteral>] Listener =
    /// Custom event emitter types.
    [<Emit("$0($1...)")>] abstract Invoke: [<ParamArray>] args: obj option[] -> unit

type EventsMapping =
    Record<string, Listener>

type [<AllowNullLiteral>] ITypedEventEmitter<'Events> =
    abstract rawEmitter: EventEmitter with get, set
    abstract eventNames: unit -> Array<KeyOf<'Events>>
    abstract setMaxListeners: n: float -> ITypedEventEmitter<'Events>
    abstract getMaxListeners: unit -> float
    abstract emit: ``type``: KeyOf<'Events> * [<ParamArray>] args: Parameters<obj> -> bool
    abstract addListener: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract on: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract once: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract prependListener: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract prependOnceListener: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract removeListener: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract off: ``type``: KeyOf<'Events> * listener: obj -> ITypedEventEmitter<'Events>
    abstract removeAllListeners: ?``type``: KeyOf<'Events> -> ITypedEventEmitter<'Events>
    abstract listeners: ``type``: KeyOf<'Events> -> ResizeArray<obj>
    abstract listenerCount: ``type``: KeyOf<'Events> -> float
    abstract rawListeners: ``type``: KeyOf<'Events> -> ResizeArray<obj>

[<AllowNullLiteral>] 
type TypedEventEmitter<'Events> =
    inherit ITypedEventEmitter<'Events>

type [<AllowNullLiteral>] TypedEventEmitterStatic =
    [<EmitConstructor>] abstract Create: unit -> TypedEventEmitter<'Events>