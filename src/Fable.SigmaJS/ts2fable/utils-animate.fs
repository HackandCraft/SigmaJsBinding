// ts2fable 0.9.0
module rec UtilsAnimate

open Fable.Core
open GraphologyTypes
//[<Erase>] type KeyOf<'T> = Key of string

type PlainObject<'T> = JsNative
let [<Import("ANIMATE_DEFAULTS","module")>] ANIMATE_DEFAULTS: {| easing: string; duration: float |} = jsNative

type [<AllowNullLiteral>] IExports =
    /// Function used to animate the nodes.
    abstract animateNodes: graph: AbstractGraph * targets: PlainObject<PlainObject<float>> * opts: obj * ?callback: (unit -> unit) -> (unit -> unit)

/// Defaults.
type Easing =
    U2<KeyOf<obj>, (float -> float)>

type [<AllowNullLiteral>] AnimateOptions =
    abstract easing: Easing with get, set
    abstract duration: float with get, set