// ts2fable 0.9.0
module rec Dijkstra

open Fable.Core

open GraphologyTypes
open UtilsGetters

type Array<'T> = System.Collections.Generic.IList<'T>

type [<AllowNullLiteral>] IExports =
    abstract bidirectional: graph: AbstractGraph<'NodeAttributes, 'EdgeAttributes> * source: obj * target: obj * ?getEdgeWeight: U2<KeyOf<'EdgeAttributes>, MinimalEdgeMapper<float, 'EdgeAttributes>> -> BidirectionalDijstraResult when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes
    abstract singleSource: graph: AbstractGraph<'NodeAttributes, 'EdgeAttributes> * source: obj * ?getEdgeWeight: U2<KeyOf<'EdgeAttributes>, MinimalEdgeMapper<float, 'EdgeAttributes>> -> SingleSourceDijkstraResult when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes
    abstract brandes: graph: AbstractGraph<'NodeAttributes, 'EdgeAttributes> * source: obj * ?getEdgeWeight: U2<KeyOf<'EdgeAttributes>, MinimalEdgeMapper<float, 'EdgeAttributes>> -> BrandesResult when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes

type [<AllowNullLiteral>] SingleSourceDijkstraResult =
    [<EmitIndexer>] abstract Item: key: string -> ResizeArray<string> with get, set

type BidirectionalDijstraResult =
    ResizeArray<string>

type BrandesResult =
    Array<string> * BrandesResult2 * BrandesResult3

type [<AllowNullLiteral>] BrandesResult2 =
    [<EmitIndexer>] abstract Item: key: string -> Array<string> with get, set

type [<AllowNullLiteral>] BrandesResult3 =
    [<EmitIndexer>] abstract Item: key: string -> float with get, set

[<Import("dijkstra", "graphology-shortest-path")>]
let export': IExports = jsNative
