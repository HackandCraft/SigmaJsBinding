// ts2fable 0.9.0
module rec Sigma

#nowarn "3390" // disable warnings for invalid XML comments
open GraphologyTypes
open SigmaBaseTypes
open SigmaCamera
open SigmaSettings
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
type MouseCaptor = obj
type TouchCaptor = obj
type Graph = AbstractGraph

//[<Erase>] type KeyOf<'T> = Key of string

type [<AllowNullLiteral>] IExports =
    /// <summary>Main class.</summary>
    /// <param name="graph">Graph to render.</param>
    /// <param name="container">DOM container in which to render.</param>
    /// <param name="settings">Optional settings.</param>
    abstract Sigma: SigmaStatic

/// Event types.
type [<AllowNullLiteral>] SigmaEventPayload =
    abstract ``event``: MouseCoords with get, set
    abstract preventSigmaDefault: unit -> unit

type [<AllowNullLiteral>] SigmaStageEventPayload =
    inherit SigmaEventPayload

type [<AllowNullLiteral>] SigmaNodeEventPayload =
    inherit SigmaEventPayload
    abstract node: string with get, set

type [<AllowNullLiteral>] SigmaEdgeEventPayload =
    inherit SigmaEventPayload
    abstract edge: string with get, set

type [<AllowNullLiteral>] SigmaStageEvents =
    interface end

type [<AllowNullLiteral>] SigmaNodeEvents =
    interface end

type [<AllowNullLiteral>] SigmaEdgeEvents =
    interface end

type [<AllowNullLiteral>] SigmaAdditionalEvents =
    abstract beforeRender: unit -> unit
    abstract afterRender: unit -> unit
    abstract resize: unit -> unit
    abstract kill: unit -> unit
    abstract enterNode: payload: SigmaNodeEventPayload -> unit
    abstract leaveNode: payload: SigmaNodeEventPayload -> unit
    abstract enterEdge: payload: SigmaEdgeEventPayload -> unit
    abstract leaveEdge: payload: SigmaEdgeEventPayload -> unit

type [<AllowNullLiteral>] SigmaEvents =
    interface end

/// <summary>Main class.</summary>
/// <param name="graph">Graph to render.</param>
/// <param name="container">DOM container in which to render.</param>
/// <param name="settings">Optional settings.</param>
type Sigma =
    Sigma<Graph>

/// <summary>Main class.</summary>
/// <param name="graph">Graph to render.</param>
/// <param name="container">DOM container in which to render.</param>
/// <param name="settings">Optional settings.</param>
type [<AllowNullLiteral>] Sigma<'GraphType when 'GraphType :> Graph> =
    inherit TypedEventEmitter<SigmaEvents>
    /// <summary>Method returning the renderer's camera.</summary>
    /// <returns />
    abstract getCamera: unit -> Camera
    /// <summary>Method setting the renderer's camera.</summary>
    /// <param name="camera">New camera.</param>
    /// <returns />
    abstract setCamera: camera: Camera -> unit
    /// <summary>Method returning the container DOM element.</summary>
    /// <returns />
    abstract getContainer: unit -> HTMLElement
    /// <summary>Method returning the renderer's graph.</summary>
    /// <returns />
    abstract getGraph: unit -> 'GraphType
    /// <summary>Method used to set the renderer's graph.</summary>
    /// <returns />
    abstract setGraph: graph: 'GraphType -> unit
    /// <summary>Method returning the mouse captor.</summary>
    /// <returns />
    abstract getMouseCaptor: unit -> MouseCaptor
    /// <summary>Method returning the touch captor.</summary>
    /// <returns />
    abstract getTouchCaptor: unit -> TouchCaptor
    /// <summary>Method returning the current renderer's dimensions.</summary>
    /// <returns />
    abstract getDimensions: unit -> Dimensions
    /// <summary>Method returning the current graph's dimensions.</summary>
    /// <returns />
    abstract getGraphDimensions: unit -> Dimensions
    /// <summary>
    /// Method used to get all the sigma node attributes.
    /// It's usefull for example to get the position of a node
    /// and to get values that are set by the nodeReducer
    /// </summary>
    /// <param name="key">The node's key.</param>
    /// <returns>A copy of the desired node's attribute or undefined if not found</returns>
    abstract getNodeDisplayData: key: obj -> NodeDisplayData option
    /// <summary>
    /// Method used to get all the sigma edge attributes.
    /// It's useful for example to get values that are set by the edgeReducer.
    /// </summary>
    /// <param name="key">The edge's key.</param>
    /// <returns>A copy of the desired edge's attribute or undefined if not found</returns>
    abstract getEdgeDisplayData: key: obj -> EdgeDisplayData option
    /// <summary>Method used to get the set of currently displayed node labels.</summary>
    /// <returns>A set of node keys whose label is displayed.</returns>
    abstract getNodeDisplayedLabels: unit -> Set<string>
    /// <summary>Method used to get the set of currently displayed edge labels.</summary>
    /// <returns>A set of edge keys whose label is displayed.</returns>
    abstract getEdgeDisplayedLabels: unit -> Set<string>
    /// <summary>Method returning a copy of the settings collection.</summary>
    /// <returns>A copy of the settings collection.</returns>
    abstract getSettings: unit -> Settings
    /// <summary>Method returning the current value for a given setting key.</summary>
    /// <param name="key">The setting key to get.</param>
    /// <returns>The value attached to this setting key or undefined if not found</returns>
    abstract getSetting: key: KeyOf<Settings> -> obj option
    /// <summary>
    /// Method setting the value of a given setting key. Note that this will schedule
    /// a new render next frame.
    /// </summary>
    /// <param name="key">The setting key to set.</param>
    /// <param name="value">The value to set.</param>
    /// <returns />
    abstract setSetting: key: KeyOf<Settings> * value: obj -> Sigma<'GraphType>
    /// <summary>
    /// Method updating the value of a given setting key using the provided function.
    /// Note that this will schedule a new render next frame.
    /// </summary>
    /// <param name="key">The setting key to set.</param>
    /// <param name="updater">The update function.</param>
    /// <returns />
    abstract updateSetting: key: KeyOf<Settings> * updater: (obj -> obj) -> Sigma<'GraphType>
    /// <summary>Method used to resize the renderer.</summary>
    /// <returns />
    abstract resize: unit -> Sigma<'GraphType>
    /// <summary>Method used to clear all the canvases.</summary>
    /// <returns />
    abstract clear: unit -> Sigma<'GraphType>
    /// <summary>
    /// Method used to refresh, i.e. force the renderer to reprocess graph
    /// data and render, but keep the state.
    /// - if a partialGraph is provided, we only reprocess those nodes &amp; edges.
    /// - if schedule is TRUE, we schedule a render instead of sync render
    /// - if skipIndexation is TRUE, then labelGrid &amp; program indexation are skipped (can be used if you haven't modify x, y, zIndex &amp; size)
    /// </summary>
    /// <returns />
    abstract refresh: ?opts: {| partialGraph: {| nodes: ResizeArray<string> option; edges: ResizeArray<string> option |} option; schedule: bool option; skipIndexation: bool option |} -> Sigma<'GraphType>
    /// <summary>
    /// Method used to schedule a render at the next available frame.
    /// This method can be safely called on a same frame because it basically
    /// debounces refresh to the next frame.
    /// </summary>
    /// <returns />
    abstract scheduleRender: unit -> Sigma<'GraphType>
    /// <summary>
    /// Method used to schedule a refresh (i.e. fully reprocess graph data and render)
    /// at the next available frame.
    /// This method can be safely called on a same frame because it basically
    /// debounces refresh to the next frame.
    /// </summary>
    /// <returns />
    abstract scheduleRefresh: ?opts: {| partialGraph: {| nodes: ResizeArray<string> option; edges: ResizeArray<string> option |} option; layoutUnchange: bool option |} -> Sigma<'GraphType>
    /// <summary>
    /// Method used to (un)zoom, while preserving the position of a viewport point.
    /// Used for instance to zoom "on the mouse cursor".
    /// </summary>
    /// <param name="viewportTarget" />
    /// <param name="newRatio" />
    /// <returns />
    abstract getViewportZoomedState: viewportTarget: Coordinates * newRatio: float -> CameraState
    /// <summary>
    /// Method returning the abstract rectangle containing the graph according
    /// to the camera's state.
    /// </summary>
    /// <returns>- The view's rectangle.</returns>
    abstract viewRectangle: unit -> SigmaViewRectangleReturn
    /// Method returning the coordinates of a point from the framed graph system to the viewport system. It allows
    /// overriding anything that is used to get the translation matrix, or even the matrix itself.
    /// 
    /// Be careful if overriding dimensions, padding or cameraState, as the computation of the matrix is not the lightest
    /// of computations.
    abstract framedGraphToViewport: coordinates: Coordinates * ?``override``: CoordinateConversionOverride -> Coordinates
    /// Method returning the coordinates of a point from the viewport system to the framed graph system. It allows
    /// overriding anything that is used to get the translation matrix, or even the matrix itself.
    /// 
    /// Be careful if overriding dimensions, padding or cameraState, as the computation of the matrix is not the lightest
    /// of computations.
    abstract viewportToFramedGraph: coordinates: Coordinates * ?``override``: CoordinateConversionOverride -> Coordinates
    /// <summary>
    /// Method used to translate a point's coordinates from the viewport system (pixel distance from the top-left of the
    /// stage) to the graph system (the reference system of data as they are in the given graph instance).
    /// 
    /// This method accepts an optional camera which can be useful if you need to translate coordinates
    /// based on a different view than the one being currently being displayed on screen.
    /// </summary>
    /// <param name="viewportPoint" />
    /// <param name="override" />
    abstract viewportToGraph: viewportPoint: Coordinates * ?``override``: CoordinateConversionOverride -> Coordinates
    /// <summary>
    /// Method used to translate a point's coordinates from the graph system (the reference system of data as they are in
    /// the given graph instance) to the viewport system (pixel distance from the top-left of the stage).
    /// 
    /// This method accepts an optional camera which can be useful if you need to translate coordinates
    /// based on a different view than the one being currently being displayed on screen.
    /// </summary>
    /// <param name="graphPoint" />
    /// <param name="override" />
    abstract graphToViewport: graphPoint: Coordinates * ?``override``: CoordinateConversionOverride -> Coordinates
    /// Method returning the distance multiplier between the graph system and the
    /// viewport system.
    abstract getGraphToViewportRatio: unit -> float
    /// <summary>Method returning the graph's bounding box.</summary>
    /// <returns />
    abstract getBBox: unit -> {| x: Extent; y: Extent |}
    /// <summary>Method returning the graph's custom bounding box, if any.</summary>
    /// <returns />
    abstract getCustomBBox: unit -> {| x: Extent; y: Extent |} option
    /// <summary>Method used to override the graph's bounding box with a custom one. Give <c>null</c> as the argument to stop overriding.</summary>
    /// <returns />
    abstract setCustomBBox: customBBox: {| x: Extent; y: Extent |} option -> Sigma<'GraphType>
    /// <summary>Method used to shut the container &amp; release event listeners.</summary>
    /// <returns />
    abstract kill: unit -> unit
    /// <summary>
    /// Method used to scale the given size according to the camera's ratio, i.e.
    /// zooming state.
    /// </summary>
    /// <param name="size">The size to scale (node size, edge thickness etc.).</param>
    /// <param name="cameraRatio">A camera ratio (defaults to the actual camera ratio).</param>
    /// <returns>- The scaled size.</returns>
    abstract scaleSize: ?size: float * ?cameraRatio: float -> float
    /// <summary>
    /// Method that returns the collection of all used canvases.
    /// At the moment, the instantiated canvases are the following, and in the
    /// following order in the DOM:
    /// - <c>edges</c>
    /// - <c>nodes</c>
    /// - <c>edgeLabels</c>
    /// - <c>labels</c>
    /// - <c>hovers</c>
    /// - <c>hoverNodes</c>
    /// - <c>mouse</c>
    /// </summary>
    /// <returns>- The collection of canvases.</returns>
    abstract getCanvases: unit -> PlainObject<HTMLCanvasElement>

type [<AllowNullLiteral>] SigmaViewRectangleReturn =
    abstract x1: float with get, set
    abstract y1: float with get, set
    abstract x2: float with get, set
    abstract y2: float with get, set
    abstract height: float with get, set

/// <summary>Main class.</summary>
/// <param name="graph">Graph to render.</param>
/// <param name="container">DOM container in which to render.</param>
/// <param name="settings">Optional settings.</param>
type [<AllowNullLiteral>] SigmaStatic =
    [<EmitConstructor>] abstract Create: graph: AbstractGraph<'A, 'B> * container: HTMLElement * ?settings: obj -> Sigma<AbstractGraph >