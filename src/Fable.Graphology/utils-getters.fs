// ts2fable 0.9.0
module rec UtilsGetters
open System
open Fable.Core
open Fable.Core.JS
open GraphologyTypes


type [<AllowNullLiteral>] IExports =
    abstract createNodeValueGetter: ?target: U2<string, NodeMapper<'T, 'NodeAttributes>> * ?defaultValue: U2<'T, (obj -> 'T)> -> NodeValueGetter<'T, 'NodeAttributes> when 'NodeAttributes :> Attributes
    abstract createEdgeValueGetter: ?target: U3<string, EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes>, PartialEdgeMapper<'T, 'EdgeAttributes>> * ?defaultValue: U2<'T, (obj -> 'T)> -> EdgeValueGetter<'T, 'NodeAttributes, 'EdgeAttributes> when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes
    abstract createEdgeWeightGetter: ?target: U3<string, EdgeMapper<float, 'NodeAttributes, 'EdgeAttributes>, PartialEdgeMapper<float, 'EdgeAttributes>> -> EdgeValueGetter<float, 'NodeAttributes, 'EdgeAttributes> when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes

type PartialEdgeMapper<'T> =
    PartialEdgeMapper<'T, Attributes>

type [<AllowNullLiteral>] PartialEdgeMapper<'T, 'EdgeAttributes when 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: edge: string * attributes: 'EdgeAttributes * source: string * target: string -> 'T

type MinimalEdgeMapper<'T> =
    MinimalEdgeMapper<'T, Attributes>

type [<AllowNullLiteral>] MinimalEdgeMapper<'T, 'EdgeAttributes when 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: edge: string * attributes: 'EdgeAttributes -> 'T

type NodeValueGetter<'T> =
    NodeValueGetter<'T, Attributes>

type [<AllowNullLiteral>] NodeValueGetter<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    abstract fromGraph: graph: AbstractGraph<'NodeAttributes> * node: obj -> 'T
    abstract fromAttributes: attributes: 'NodeAttributes -> 'T
    abstract fromEntry: NodeMapper<'T, 'NodeAttributes> with get, set

type EdgeValueGetter<'T> =
    EdgeValueGetter<'T, Attributes, Attributes>

type EdgeValueGetter<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgeValueGetter<'T, 'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgeValueGetter<'T, 'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    abstract fromGraph: graph: AbstractGraph<'NodeAttributes, 'EdgeAttributes> * edge: obj -> 'T
    abstract fromAttributes: attributes: 'EdgeAttributes -> 'T
    abstract fromEntry: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> with get, set
    abstract fromPartialEntry: PartialEdgeMapper<'T, 'EdgeAttributes> with get, set
    abstract fromMinimalEntry: MinimalEdgeMapper<'T, 'EdgeAttributes> with get, set