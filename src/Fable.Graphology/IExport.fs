// ts2fable 0.9.0
module rec GraphologyTypes

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core

type IterableIterator<'A> = JsNative
type Record<'A, 'B> = JsNative
type Omit<'A, 'B> = JsNative
type Parameters<'A> = JsNative

[<Erase>] type KeyOf<'T> = Key of string

type Array<'T> = System.Collections.Generic.IList<'T>


type [<AllowNullLiteral>] IExports =
    abstract GraphEventEmitter: GraphEventEmitterStatic
    /// Main interface.
    abstract AbstractGraph: AbstractGraphStatic
    abstract GraphConstructor: GraphConstructorStatic

/// Miscellaneous types.
type [<AllowNullLiteral>] Attributes =
    [<EmitIndexer>] abstract Item: name: string -> obj option with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] GraphType =
    | Mixed
    | Directed
    | Undirected

type UpdateHints =
    UpdateHints<Attributes>

type [<AllowNullLiteral>] UpdateHints<'ItemAttributes when 'ItemAttributes :> Attributes> =
    abstract attributes: Array<KeyOf<'ItemAttributes>> option with get, set

type [<AllowNullLiteral>] GraphOptions =
    abstract allowSelfLoops: bool option with get, set
    abstract multi: bool option with get, set
    abstract ``type``: GraphType option with get, set

type AdjacencyEntry =
    AdjacencyEntry<Attributes, Attributes>

type AdjacencyEntry<'NodeAttributes when 'NodeAttributes :> Attributes> =
    AdjacencyEntry<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] AdjacencyEntry<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    abstract source: string with get, set
    abstract target: string with get, set
    abstract sourceAttributes: 'NodeAttributes with get, set
    abstract targetAttributes: 'NodeAttributes with get, set
    abstract edge: string with get, set
    abstract edgeAttributes: 'EdgeAttributes with get, set
    abstract undirected: bool with get, set

type NodeEntry =
    NodeEntry<Attributes>

type [<AllowNullLiteral>] NodeEntry<'NodeAttributes when 'NodeAttributes :> Attributes> =
    abstract node: string with get, set
    abstract attributes: 'NodeAttributes with get, set

type NodeMergeResult =
    obj * obj

type NeighborEntry =
    NeighborEntry<Attributes>

type [<AllowNullLiteral>] NeighborEntry<'NodeAttributes when 'NodeAttributes :> Attributes> =
    abstract neighbor: string with get, set
    abstract attributes: 'NodeAttributes with get, set

type EdgeEntry =
    EdgeEntry<Attributes, Attributes>

type EdgeEntry<'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgeEntry<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgeEntry<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    abstract edge: string with get, set
    abstract attributes: 'EdgeAttributes with get, set
    abstract source: string with get, set
    abstract target: string with get, set
    abstract sourceAttributes: 'NodeAttributes with get, set
    abstract targetAttributes: 'NodeAttributes with get, set
    abstract undirected: bool with get, set

type EdgeMergeResult =
    obj * obj * obj * obj

type AdjacencyIterationCallback =
    AdjacencyIterationCallback<Attributes, Attributes>

type AdjacencyIterationCallback<'NodeAttributes when 'NodeAttributes :> Attributes> =
    AdjacencyIterationCallback<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] AdjacencyIterationCallback<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * neighbor: string * nodeAttributes: 'NodeAttributes * neighborAttributes: 'NodeAttributes * edge: string * edgeAttributes: 'EdgeAttributes * undirected: bool -> unit

type AdjacencyIterationCallbackWithOrphans =
    AdjacencyIterationCallbackWithOrphans<Attributes, Attributes>

type AdjacencyIterationCallbackWithOrphans<'NodeAttributes when 'NodeAttributes :> Attributes> =
    AdjacencyIterationCallbackWithOrphans<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] AdjacencyIterationCallbackWithOrphans<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * neighbor: string option * nodeAttributes: 'NodeAttributes * neighborAttributes: 'NodeAttributes option * edge: string option * edgeAttributes: 'EdgeAttributes option * undirected: bool option -> unit

type NodeIterationCallback =
    NodeIterationCallback<Attributes>

type [<AllowNullLiteral>] NodeIterationCallback<'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * attributes: 'NodeAttributes -> unit

type NodePredicate =
    NodePredicate<Attributes>

type [<AllowNullLiteral>] NodePredicate<'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * attributes: 'NodeAttributes -> U2<bool, unit>

type NodeMapper<'T> =
    NodeMapper<'T, Attributes>

type [<AllowNullLiteral>] NodeMapper<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * attributes: 'NodeAttributes -> 'T

type [<AllowNullLiteral>] NodeMapper2<'T,'R, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: node: string * attributes: 'NodeAttributes -> 'R

type NodeReducer<'T> =
    NodeReducer<'T, Attributes>

type [<AllowNullLiteral>] NodeReducer<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: accumulator: 'T * node: string * attributes: 'NodeAttributes -> 'T

type NeighborIterationCallback =
    NeighborIterationCallback<Attributes>

type [<AllowNullLiteral>] NeighborIterationCallback<'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: neighbor: string * attributes: 'NodeAttributes -> unit

type NeighborPredicate =
    NeighborPredicate<Attributes>

type [<AllowNullLiteral>] NeighborPredicate<'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: neighbor: string * attributes: 'NodeAttributes -> U2<bool, unit>

type NeighborMapper<'T> =
    NeighborMapper<'T, Attributes>

type [<AllowNullLiteral>] NeighborMapper<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: neighbor: string * attributes: 'NodeAttributes -> 'T

type NeighborReducer<'T> =
    NeighborReducer<'T, Attributes>

type [<AllowNullLiteral>] NeighborReducer<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: accumulator: 'T * neighbor: string * attributes: 'NodeAttributes -> 'T

type EdgeIterationCallback =
    EdgeIterationCallback<Attributes, Attributes>

type EdgeIterationCallback<'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgeIterationCallback<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: edge: string * attributes: 'EdgeAttributes * source: string * target: string * sourceAttributes: 'NodeAttributes * targetAttributes: 'NodeAttributes * undirected: bool -> unit

type EdgePredicate =
    EdgePredicate<Attributes, Attributes>

type EdgePredicate<'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgePredicate<'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgePredicate<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: edge: string * attributes: 'EdgeAttributes * source: string * target: string * sourceAttributes: 'NodeAttributes * targetAttributes: 'NodeAttributes * undirected: bool -> U2<bool, unit>

type EdgeMapper<'T> =
    EdgeMapper<'T, Attributes, Attributes>

type EdgeMapper<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgeMapper<'T, 'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: edge: string * attributes: 'EdgeAttributes * source: string * target: string * sourceAttributes: 'NodeAttributes * targetAttributes: 'NodeAttributes * undirected: bool -> 'T

type EdgeReducer<'T> =
    EdgeReducer<'T, Attributes, Attributes>

type EdgeReducer<'T, 'NodeAttributes when 'NodeAttributes :> Attributes> =
    EdgeReducer<'T, 'NodeAttributes, Attributes>

type [<AllowNullLiteral>] EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    [<Emit("$0($1...)")>] abstract Invoke: accumulator: 'T * edge: string * attributes: 'EdgeAttributes * source: string * target: string * sourceAttributes: 'NodeAttributes * targetAttributes: 'NodeAttributes * undirected: bool -> 'T

type SerializedNode =
    SerializedNode<Attributes>

type [<AllowNullLiteral>] SerializedNode<'NodeAttributes when 'NodeAttributes :> Attributes> =
    abstract key: string with get, set
    abstract attributes: 'NodeAttributes option with get, set

type SerializedEdge =
    SerializedEdge<Attributes>

type [<AllowNullLiteral>] SerializedEdge<'EdgeAttributes when 'EdgeAttributes :> Attributes> =
    abstract key: string option with get, set
    abstract source: string with get, set
    abstract target: string with get, set
    abstract attributes: 'EdgeAttributes option with get, set
    abstract undirected: bool option with get, set

type SerializedGraph =
    SerializedGraph<Attributes, Attributes, Attributes>

type SerializedGraph<'NodeAttributes when 'NodeAttributes :> Attributes> =
    SerializedGraph<'NodeAttributes, Attributes, Attributes>

type SerializedGraph<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    SerializedGraph<'NodeAttributes, 'EdgeAttributes, Attributes>

type [<AllowNullLiteral>] SerializedGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes and 'GraphAttributes :> Attributes> =
    abstract attributes: 'GraphAttributes with get, set
    abstract options: GraphOptions with get, set
    abstract nodes: Array<SerializedNode<'NodeAttributes>> with get, set
    abstract edges: Array<SerializedEdge<'EdgeAttributes>> with get, set

/// <summary>Event Emitter typings for convience.</summary>
/// <remarks>Taken from here: <see href="https://github.com/DefinitelyTyped/DefinitelyTyped/blob/master/types/events/index.d.ts" /></remarks>
type [<AllowNullLiteral>] Listener =
    /// <summary>Event Emitter typings for convience.</summary>
    /// <remarks>Taken from here: <see href="https://github.com/DefinitelyTyped/DefinitelyTyped/blob/master/types/events/index.d.ts" /></remarks>
    [<Emit("$0($1...)")>] abstract Invoke: [<ParamArray>] args: obj option[] -> unit

type EventsMapping =
    Record<string, Listener>

type [<StringEnum>] [<RequireQualifiedAccess>] AttributeUpdateType =
    | Set
    | Remove
    | Replace
    | Merge
    | Update

type AttributeUpdatePayload =
    AttributeUpdatePayload<Attributes>

type AttributeUpdatePayload<'ItemAttributes when 'ItemAttributes :> Attributes> =
    U5<{| ``type``: string; key: string; attributes: 'ItemAttributes; name: string |}, {| ``type``: string; key: string; attributes: 'ItemAttributes; name: string |}, {| ``type``: string; key: string; attributes: 'ItemAttributes |}, {| ``type``: string; key: string; attributes: 'ItemAttributes; data: 'ItemAttributes |}, {| ``type``: string; key: string; attributes: 'ItemAttributes |}>

type GraphEvents =
    GraphEvents<Attributes, Attributes, Attributes>

type GraphEvents<'NodeAttributes when 'NodeAttributes :> Attributes> =
    GraphEvents<'NodeAttributes, Attributes, Attributes>

type GraphEvents<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    GraphEvents<'NodeAttributes, 'EdgeAttributes, Attributes>

type [<AllowNullLiteral>] GraphEvents<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes and 'GraphAttributes :> Attributes> =
    abstract nodeAdded: payload: {| key: string; attributes: 'NodeAttributes |} -> unit
    abstract edgeAdded: payload: GraphEventsEdgeAdded<'EdgeAttributes> -> unit
    abstract nodeDropped: payload: {| key: string; attributes: 'NodeAttributes |} -> unit
    abstract edgeDropped: payload: GraphEventsEdgeAdded<'EdgeAttributes> -> unit
    abstract cleared: unit -> unit
    abstract edgesCleared: unit -> unit
    abstract attributesUpdated: payload: Omit<AttributeUpdatePayload<'GraphAttributes>, string> -> unit
    abstract nodeAttributesUpdated: payload: AttributeUpdatePayload<'NodeAttributes> -> unit
    abstract edgeAttributesUpdated: payload: AttributeUpdatePayload<'EdgeAttributes> -> unit
    abstract eachNodeAttributesUpdated: payload: {| hints: UpdateHints<'NodeAttributes> |} -> unit
    abstract eachEdgeAttributesUpdated: payload: {| hints: UpdateHints<'EdgeAttributes> |} -> unit

type [<AllowNullLiteral>] GraphEventEmitter<'Events> =
    abstract eventNames: unit -> Array<KeyOf<'Events>>
    abstract setMaxListeners: n: float -> GraphEventEmitter<'Events>
    abstract getMaxListeners: unit -> float
    abstract emit: ``type``: KeyOf<'Events> * [<ParamArray>] args: Parameters<obj> -> bool
    abstract addListener: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract on: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract once: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract prependListener: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract prependOnceListener: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract removeListener: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract off: ``type``: KeyOf<'Events> * listener: obj -> GraphEventEmitter<'Events>
    abstract removeAllListeners: ?``type``: KeyOf<'Events> -> GraphEventEmitter<'Events>
    abstract listeners: ``type``: KeyOf<'Events> -> ResizeArray<obj>
    abstract listenerCount: ``type``: KeyOf<'Events> -> float
    abstract rawListeners: ``type``: KeyOf<'Events> -> ResizeArray<obj>

type [<AllowNullLiteral>] GraphEventEmitterStatic =
    [<EmitConstructor>] abstract Create: unit -> GraphEventEmitter<'Events> when 'Events :> EventsMapping
    abstract listenerCount: emitter: GraphEventEmitter<'Events> * ``type``: U2<string, float> -> float when 'Events :> EventsMapping
    abstract defaultMaxListeners: float with get, set

/// Main interface.
type AbstractGraph =
    AbstractGraph<Attributes, Attributes, Attributes>

/// Main interface.
type AbstractGraph<'NodeAttributes when 'NodeAttributes :> Attributes> =
    AbstractGraph<'NodeAttributes, Attributes, Attributes>

/// Main interface.
type AbstractGraph<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    AbstractGraph<'NodeAttributes, 'EdgeAttributes, Attributes>

/// Main interface.
type [<AllowNullLiteral>] AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes and 'GraphAttributes :> Attributes> =
    inherit GraphEventEmitter<GraphEvents<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>>
    abstract order: float with get, set
    abstract size: float with get, set
    abstract directedSize: float with get, set
    abstract undirectedSize: float with get, set
    abstract ``type``: GraphType with get, set
    abstract multi: bool with get, set
    abstract allowSelfLoops: bool with get, set
    abstract implementation: string with get, set
    abstract selfLoopCount: float with get, set
    abstract directedSelfLoopCount: float with get, set
    abstract undirectedSelfLoopCount: float with get, set
    abstract hasNode: node: obj -> bool
    abstract hasDirectedEdge: edge: obj -> bool
    abstract hasDirectedEdge: source: obj * target: obj -> bool
    abstract hasUndirectedEdge: edge: obj -> bool
    abstract hasUndirectedEdge: source: obj * target: obj -> bool
    abstract hasEdge: edge: obj -> bool
    abstract hasEdge: source: obj * target: obj -> bool
    abstract directedEdge: source: obj * target: obj -> string option
    abstract undirectedEdge: source: obj * target: obj -> string option
    abstract edge: source: obj * target: obj -> string option
    abstract inDegree: node: obj -> float
    abstract outDegree: node: obj -> float
    abstract inboundDegree: node: obj -> float
    abstract outboundDegree: node: obj -> float
    abstract directedDegree: node: obj -> float
    abstract undirectedDegree: node: obj -> float
    abstract degree: node: obj -> float
    abstract inDegreeWithoutSelfLoops: node: obj -> float
    abstract outDegreeWithoutSelfLoops: node: obj -> float
    abstract inboundDegreeWithoutSelfLoops: node: obj -> float
    abstract outboundDegreeWithoutSelfLoops: node: obj -> float
    abstract directedDegreeWithoutSelfLoops: node: obj -> float
    abstract undirectedDegreeWithoutSelfLoops: node: obj -> float
    abstract degreeWithoutSelfLoops: node: obj -> float
    abstract source: edge: obj -> string
    abstract target: edge: obj -> string
    abstract extremities: edge: obj -> string * string
    abstract opposite: node: obj * edge: obj -> string
    abstract isUndirected: edge: obj -> bool
    abstract isDirected: edge: obj -> bool
    abstract isSelfLoop: edge: obj -> bool
    abstract hasExtremity: edge: obj * node: obj -> bool
    abstract areNeighbors: source: obj * target: obj -> bool
    abstract areUndirectedNeighbors: source: obj * target: obj -> bool
    abstract areDirectedNeighbors: source: obj * target: obj -> bool
    abstract areInNeighbors: source: obj * target: obj -> bool
    abstract areOutNeighbors: source: obj * target: obj -> bool
    abstract areInboundNeighbors: source: obj * target: obj -> bool
    abstract areOutboundNeighbors: source: obj * target: obj -> bool
    abstract addNode: node: obj * ?attributes: 'NodeAttributes -> string
    abstract mergeNode: node: obj * ?attributes: obj -> NodeMergeResult
    abstract updateNode: node: obj * ?updater: (obj -> 'NodeAttributes) -> NodeMergeResult
    abstract addEdge: source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeEdge: source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateEdge: source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract addDirectedEdge: source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeDirectedEdge: source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateDirectedEdge: source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract addUndirectedEdge: source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeUndirectedEdge: source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateUndirectedEdge: source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract addEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateEdgeWithKey: edge: obj * source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract addDirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeDirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateDirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract addUndirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: 'EdgeAttributes -> string
    abstract mergeUndirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?attributes: obj -> EdgeMergeResult
    abstract updateUndirectedEdgeWithKey: edge: obj * source: obj * target: obj * ?updater: (obj -> 'EdgeAttributes) -> EdgeMergeResult
    abstract dropNode: node: obj -> unit
    abstract dropEdge: edge: obj -> unit
    abstract dropEdge: source: obj * target: obj -> unit
    abstract dropDirectedEdge: source: obj * target: obj -> unit
    abstract dropUndirectedEdge: source: obj * target: obj -> unit
    abstract clear: unit -> unit
    abstract clearEdges: unit -> unit
    abstract getAttribute: name: KeyOf<'GraphAttributes> -> obj
    abstract getAttributes: unit -> 'GraphAttributes
    abstract hasAttribute: name: KeyOf<'GraphAttributes> -> bool
    abstract setAttribute: name: KeyOf<'GraphAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateAttribute: name: KeyOf<'GraphAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeAttribute: name: KeyOf<'GraphAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceAttributes: attributes: 'GraphAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeAttributes: attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateAttributes: updater: ('GraphAttributes -> 'GraphAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getNodeAttribute: node: obj * name: KeyOf<'NodeAttributes> -> obj
    abstract getNodeAttributes: node: obj -> 'NodeAttributes
    abstract hasNodeAttribute: node: obj * name: KeyOf<'NodeAttributes> -> bool
    abstract setNodeAttribute: node: obj * name: KeyOf<'NodeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateNodeAttribute: node: obj * name: KeyOf<'NodeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeNodeAttribute: node: obj * name: KeyOf<'NodeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceNodeAttributes: node: obj * attributes: 'NodeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeNodeAttributes: node: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateNodeAttributes: node: obj * updater: ('NodeAttributes -> 'NodeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getSourceAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> obj
    abstract getSourceAttributes: edge: obj -> 'NodeAttributes
    abstract hasSourceAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> bool
    abstract setSourceAttribute: edge: obj * name: KeyOf<'NodeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateSourceAttribute: edge: obj * name: KeyOf<'NodeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeSourceAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceSourceAttributes: edge: obj * attributes: 'NodeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeSourceAttributes: edge: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateSourceAttributes: edge: obj * updater: ('NodeAttributes -> 'NodeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getTargetAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> obj
    abstract getTargetAttributes: edge: obj -> 'NodeAttributes
    abstract hasTargetAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> bool
    abstract setTargetAttribute: edge: obj * name: KeyOf<'NodeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateTargetAttribute: edge: obj * name: KeyOf<'NodeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeTargetAttribute: edge: obj * name: KeyOf<'NodeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceTargetAttributes: edge: obj * attributes: 'NodeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeTargetAttributes: edge: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateTargetAttributes: edge: obj * updater: ('NodeAttributes -> 'NodeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getOppositeAttribute: node: obj * edge: obj * name: KeyOf<'NodeAttributes> -> obj
    abstract getOppositeAttributes: node: obj -> 'NodeAttributes
    abstract hasOppositeAttribute: node: obj * edge: obj * name: KeyOf<'NodeAttributes> -> bool
    abstract setOppositeAttribute: node: obj * edge: obj * name: KeyOf<'NodeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateOppositeAttribute: node: obj * edge: obj * name: KeyOf<'NodeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeOppositeAttribute: node: obj * edge: obj * name: KeyOf<'NodeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceOppositeAttributes: node: obj * edge: obj * attributes: 'NodeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeOppositeAttributes: node: obj * edge: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateOppositeAttributes: node: obj * edge: obj * updater: ('NodeAttributes -> 'NodeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEachNodeAttributes: updater: NodeMapper<'NodeAttributes, 'NodeAttributes> * ?hints: UpdateHints<'NodeAttributes> -> unit
    abstract getEdgeAttribute: edge: obj * name: KeyOf<'EdgeAttributes> -> obj
    abstract getEdgeAttributes: edge: obj -> 'EdgeAttributes
    abstract hasEdgeAttribute: edge: obj * name: KeyOf<'EdgeAttributes> -> bool
    abstract setEdgeAttribute: edge: obj * name: KeyOf<'EdgeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEdgeAttribute: edge: obj * name: KeyOf<'EdgeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeEdgeAttribute: edge: obj * name: KeyOf<'EdgeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceEdgeAttributes: edge: obj * attributes: 'EdgeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeEdgeAttributes: edge: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEdgeAttributes: edge: obj * updater: ('EdgeAttributes -> 'EdgeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEachEdgeAttributes: updater: EdgeMapper<'EdgeAttributes, 'NodeAttributes, 'EdgeAttributes> * ?hints: UpdateHints<'EdgeAttributes> -> unit
    abstract getEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> obj
    abstract getEdgeAttributes: source: obj * target: obj -> 'EdgeAttributes
    abstract hasEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> bool
    abstract setEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceEdgeAttributes: source: obj * target: obj * attributes: 'EdgeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeEdgeAttributes: source: obj * target: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateEdgeAttributes: source: obj * target: obj * updater: ('EdgeAttributes -> 'EdgeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getDirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> obj
    abstract getDirectedEdgeAttributes: source: obj * target: obj -> 'EdgeAttributes
    abstract hasDirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> bool
    abstract setDirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateDirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeDirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceDirectedEdgeAttributes: source: obj * target: obj * attributes: 'EdgeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeDirectedEdgeAttributes: source: obj * target: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateDirectedEdgeAttributes: source: obj * target: obj * updater: ('EdgeAttributes -> 'EdgeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract getUndirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> obj
    abstract getUndirectedEdgeAttributes: source: obj * target: obj -> 'EdgeAttributes
    abstract hasUndirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> bool
    abstract setUndirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * value: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateUndirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> * updater: (obj option -> obj) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract removeUndirectedEdgeAttribute: source: obj * target: obj * name: KeyOf<'EdgeAttributes> -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract replaceUndirectedEdgeAttributes: source: obj * target: obj * attributes: 'EdgeAttributes -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract mergeUndirectedEdgeAttributes: source: obj * target: obj * attributes: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract updateUndirectedEdgeAttributes: source: obj * target: obj * updater: ('EdgeAttributes -> 'EdgeAttributes) -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract forEachAdjacencyEntry: callback: AdjacencyIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachAssymetricAdjacencyEntry: callback: AdjacencyIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachAdjacencyEntryWithOrphans: callback: AdjacencyIterationCallbackWithOrphans<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachAssymetricAdjacencyEntryWithOrphans: callback: AdjacencyIterationCallbackWithOrphans<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract nodes: unit -> Array<string>
    abstract forEachNode: callback: NodeIterationCallback<'NodeAttributes> -> unit
    abstract mapNodes: callback: NodeMapper<'T,'NodeAttributes> -> Array<'R>
    abstract filterNodes: callback: NodePredicate<'NodeAttributes> -> Array<string>
    abstract reduceNodes: callback: NodeReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract findNode: callback: NodePredicate<'NodeAttributes> -> string option
    abstract someNode: callback: NodePredicate<'NodeAttributes> -> bool
    abstract everyNode: callback: NodePredicate<'NodeAttributes> -> bool
    abstract nodeEntries: unit -> IterableIterator<NodeEntry<'NodeAttributes>>
    abstract edges: unit -> Array<string>
    abstract edges: node: obj -> Array<string>
    abstract edges: source: obj * target: obj -> Array<string>
    abstract undirectedEdges: unit -> Array<string>
    abstract undirectedEdges: node: obj -> Array<string>
    abstract undirectedEdges: source: obj * target: obj -> Array<string>
    abstract directedEdges: unit -> Array<string>
    abstract directedEdges: node: obj -> Array<string>
    abstract directedEdges: source: obj * target: obj -> Array<string>
    abstract inEdges: unit -> Array<string>
    abstract inEdges: node: obj -> Array<string>
    abstract inEdges: source: obj * target: obj -> Array<string>
    abstract outEdges: unit -> Array<string>
    abstract outEdges: node: obj -> Array<string>
    abstract outEdges: source: obj * target: obj -> Array<string>
    abstract inboundEdges: unit -> Array<string>
    abstract inboundEdges: node: obj -> Array<string>
    abstract inboundEdges: source: obj * target: obj -> Array<string>
    abstract outboundEdges: unit -> Array<string>
    abstract outboundEdges: node: obj -> Array<string>
    abstract outboundEdges: source: obj * target: obj -> Array<string>
    abstract forEachEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachUndirectedEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachUndirectedEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachUndirectedEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachDirectedEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachDirectedEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachDirectedEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInboundEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInboundEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachInboundEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutboundEdge: callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutboundEdge: node: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract forEachOutboundEdge: source: obj * target: obj * callback: EdgeIterationCallback<'NodeAttributes, 'EdgeAttributes> -> unit
    abstract mapEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapUndirectedEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapUndirectedEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapUndirectedEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapDirectedEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapDirectedEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapDirectedEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInboundEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInboundEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapInboundEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutboundEdges: callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutboundEdges: node: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract mapOutboundEdges: source: obj * target: obj * callback: EdgeMapper<'T, 'NodeAttributes, 'EdgeAttributes> -> Array<'T>
    abstract filterEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterUndirectedEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterUndirectedEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterUndirectedEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterDirectedEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterDirectedEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterDirectedEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInboundEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInboundEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterInboundEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutboundEdges: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutboundEdges: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract filterOutboundEdges: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> Array<string>
    abstract reduceEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceUndirectedEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceUndirectedEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceUndirectedEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceDirectedEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceDirectedEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceDirectedEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInboundEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInboundEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceInboundEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutboundEdges: callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutboundEdges: node: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutboundEdges: source: obj * target: obj * callback: EdgeReducer<'T, 'NodeAttributes, 'EdgeAttributes> * initialValue: 'T -> 'T
    abstract findEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findUndirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findUndirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findUndirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findDirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findDirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findDirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findInboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract findOutboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> string option
    abstract someEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someUndirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someUndirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someUndirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someDirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someDirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someDirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someInboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract someOutboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyUndirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyUndirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyUndirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyDirectedEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyDirectedEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyDirectedEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyInboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutboundEdge: callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutboundEdge: node: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract everyOutboundEdge: source: obj * target: obj * callback: EdgePredicate<'NodeAttributes, 'EdgeAttributes> -> bool
    abstract edgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract edgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract edgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract undirectedEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract undirectedEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract undirectedEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract directedEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract directedEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract directedEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inboundEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inboundEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract inboundEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outboundEdgeEntries: unit -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outboundEdgeEntries: node: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract outboundEdgeEntries: source: obj * target: obj -> IterableIterator<EdgeEntry<'NodeAttributes, 'EdgeAttributes>>
    abstract neighbors: node: obj -> Array<string>
    abstract undirectedNeighbors: node: obj -> Array<string>
    abstract directedNeighbors: node: obj -> Array<string>
    abstract inNeighbors: node: obj -> Array<string>
    abstract outNeighbors: node: obj -> Array<string>
    abstract inboundNeighbors: node: obj -> Array<string>
    abstract outboundNeighbors: node: obj -> Array<string>
    abstract forEachNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachUndirectedNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachDirectedNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachInNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachOutNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachInboundNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract forEachOutboundNeighbor: node: obj * callback: NeighborIterationCallback<'NodeAttributes> -> unit
    abstract mapNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapUndirectedNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapDirectedNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapInNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapOutNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapInboundNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract mapOutboundNeighbors: node: obj * callback: NeighborMapper<'T, 'NodeAttributes> -> Array<'T>
    abstract filterNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterUndirectedNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterDirectedNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterInNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterOutNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterInboundNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract filterOutboundNeighbors: node: obj * callback: NeighborPredicate<'NodeAttributes> -> Array<string>
    abstract reduceNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceUndirectedNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceDirectedNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceInNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceInboundNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract reduceOutboundNeighbors: node: obj * callback: NeighborReducer<'T, 'NodeAttributes> * initialValue: 'T -> 'T
    abstract findNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findUndirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findDirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findInNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findOutNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findInboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract findOutboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> string option
    abstract someNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someUndirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someDirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someInNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someOutNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someInboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract someOutboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyUndirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyDirectedNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyInNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyOutNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyInboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract everyOutboundNeighbor: node: obj * callback: NeighborPredicate<'NodeAttributes> -> bool
    abstract neighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract undirectedNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract directedNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract inNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract outNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract inboundNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract outboundNeighborEntries: node: obj -> IterableIterator<NeighborEntry<'NodeAttributes>>
    abstract export: unit -> SerializedGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract import: data: obj * ?merge: bool -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract import: graph: AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes> * ?merge: bool -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract nullCopy: ?options: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract emptyCopy: ?options: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract copy: ?options: obj -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract toJSON: unit -> SerializedGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract toString: unit -> string
    abstract inspect: unit -> obj option

/// Main interface.
type [<AllowNullLiteral>] AbstractGraphStatic =
    [<EmitConstructor>] abstract Create: ?options: GraphOptions -> AbstractGraph<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>
    abstract from: data: U2<SerializedGraph<'NA, 'EA, 'GA>, AbstractGraph<'NA, 'EA, 'GA>> * ?options: GraphOptions -> AbstractGraph<'NA, 'EA, 'GA> when 'NA :> Attributes and 'EA :> Attributes and 'GA :> Attributes

type GraphConstructor =
    GraphConstructor<Attributes, Attributes, Attributes>

type GraphConstructor<'NodeAttributes when 'NodeAttributes :> Attributes> =
    GraphConstructor<'NodeAttributes, Attributes, Attributes>

type GraphConstructor<'NodeAttributes, 'EdgeAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes> =
    GraphConstructor<'NodeAttributes, 'EdgeAttributes, Attributes>

type [<AllowNullLiteral>] GraphConstructor<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes when 'NodeAttributes :> Attributes and 'EdgeAttributes :> Attributes and 'GraphAttributes :> Attributes> =
    interface end

type [<AllowNullLiteral>] GraphConstructorStatic =
    [<EmitConstructor>] abstract Create: ?options: GraphOptions -> GraphConstructor<'NodeAttributes, 'EdgeAttributes, 'GraphAttributes>

type [<AllowNullLiteral>] GraphEventsEdgeAdded<'EdgeAttributes> =
    abstract key: string with get, set
    abstract source: string with get, set
    abstract target: string with get, set
    abstract attributes: 'EdgeAttributes with get, set
    abstract undirected: bool with get, set