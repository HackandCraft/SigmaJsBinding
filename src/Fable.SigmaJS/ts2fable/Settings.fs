// ts2fable 0.9.0
module rec SigmaSettings

open Fable.Core

type Attributes = Attributes

type EdgeProgramType = EdgeProgramType
type NodeProgramType = NodeProgramType
type EdgeLabelDrawingFunction = EdgeLabelDrawingFunction
type NodeLabelDrawingFunction = NodeLabelDrawingFunction
type NodeHoverDrawingFunction = NodeHoverDrawingFunction

type [<AllowNullLiteral>] IExports =
    abstract validateSettings: settings: Settings -> unit
    abstract resolveSettings: settings: obj -> Settings

/// Sigma.js settings
/// =================================
type [<AllowNullLiteral>] Settings =
    abstract hideEdgesOnMove: bool with get, set
    abstract hideLabelsOnMove: bool with get, set
    abstract renderLabels: bool with get, set
    abstract renderEdgeLabels: bool with get, set
    abstract enableEdgeEvents: bool with get, set
    abstract defaultNodeColor: string with get, set
    abstract defaultNodeType: string with get, set
    abstract defaultEdgeColor: string with get, set
    abstract defaultEdgeType: string with get, set
    abstract labelFont: string with get, set
    abstract labelSize: float with get, set
    abstract labelWeight: string with get, set
    abstract labelColor: U2<{| attribute: string; color: string option |}, {| color: string; attribute: obj option |}> with get, set
    abstract edgeLabelFont: string with get, set
    abstract edgeLabelSize: float with get, set
    abstract edgeLabelWeight: string with get, set
    abstract edgeLabelColor: U2<{| attribute: string; color: string option |}, {| color: string; attribute: obj option |}> with get, set
    abstract stagePadding: float with get, set
    abstract zoomToSizeRatioFunction: (float -> float) with get, set
    abstract itemSizesReference: SettingsItemSizesReference with get, set
    abstract defaultDrawEdgeLabel: EdgeLabelDrawingFunction with get, set
    abstract defaultDrawNodeLabel: NodeLabelDrawingFunction with get, set
    abstract defaultDrawNodeHover: NodeHoverDrawingFunction with get, set
    abstract labelDensity: float with get, set
    abstract labelGridCellSize: float with get, set
    abstract labelRenderedSizeThreshold: float with get, set
    abstract nodeReducer: (string -> Attributes -> obj) option with get, set
    abstract edgeReducer: (string -> Attributes -> obj) option with get, set
    abstract zIndex: bool with get, set
    abstract minCameraRatio: float option with get, set
    abstract maxCameraRatio: float option with get, set
    abstract allowInvalidContainer: bool with get, set
    abstract nodeProgramClasses: SettingsNodeProgramClasses with get, set
    abstract nodeHoverProgramClasses: SettingsNodeProgramClasses with get, set
    abstract edgeProgramClasses: SettingsEdgeProgramClasses with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] SettingsItemSizesReference =
    | Screen
    | Positions

type [<AllowNullLiteral>] SettingsNodeProgramClasses =
    [<EmitIndexer>] abstract Item: ``type``: string -> NodeProgramType with get, set

type [<AllowNullLiteral>] SettingsEdgeProgramClasses =
    [<EmitIndexer>] abstract Item: ``type``: string -> EdgeProgramType with get, set