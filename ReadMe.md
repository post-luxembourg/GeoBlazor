﻿# Blazor GIS API

[View the live demo site!](https://dy-blazor-samples-server.azurewebsites.net/)

This project wraps the [ArcGIS Javascript API](https://developers.arcgis.com/javascript/latest/) in a Blazor templating framework.
It generates a nuget package that can be imported and consumed from any Blazor application, without directly interacting with javascript.

In addition to "hiding" the javascript implementation, the goal is also to make a simple, component-based system for declaring a map and view. For example:

```html
<MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 600px; width: 100%;">
    <Map ArcGISDefaultBasemap="arcgis-topographic">
        <GraphicsLayer>
            <Graphic>
                <Point Longitude="_longitude" Latitude="_latitude"/>
                <SimpleMarkerSymbol Color="@(new MapColor(226, 119, 40))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleMarkerSymbol>
            </Graphic>
            <Graphic>
                <PolyLine Paths="@_mapPaths"/>
                <SimpleLineSymbol Color="@(new MapColor(226, 119, 40))" Width="2"/>
            </Graphic>
            <Graphic>
                <Polygon Rings="@_mapRings"/>
                <SimpleFillSymbol Color="@(new MapColor(227, 139, 79, 0.8))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleFillSymbol>
                <Attributes Name="This is a Title" Description="And a Description"/>
                <PopupTemplate Title="{Name}" Content="{Description}"/>
            </Graphic>
        </GraphicsLayer>
    </Map>
</MapView>
```

for a 2D map with a default ArcGIS basemap, or

```html
<SceneView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 600px; width: 100%;" ZIndex="2000" Tilt="76">
    <Map Ground="world-elevation">
        <Basemap>
            <PortalItem Id="f35ef07c9ed24020aadd65c8a65d3754" />
        </Basemap>
        <GraphicsLayer>
            <Graphic>
                <Point Longitude="_longitude" Latitude="_latitude"/>
                <SimpleMarkerSymbol Color="@(new MapColor(226, 119, 40))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleMarkerSymbol>
            </Graphic>
            <Graphic>
                <PolyLine Paths="@_mapPaths"/>
                <SimpleLineSymbol Color="@(new MapColor(226, 119, 40))" Width="2"/>
            </Graphic>
            <Graphic>
                <Polygon Rings="@_mapRings"/>
                <SimpleFillSymbol Color="@(new MapColor(227, 139, 79, 0.8))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleFillSymbol>
                <Attributes Name="This is a Title" Description="And a Description"/>
                <PopupTemplate Title="{Name}" Content="{Description}"/>
            </Graphic>
        </GraphicsLayer>
    </Map>
</SceneView>
```

for a 3D map with a basemap loaded from a `PortalId`.

## Using the Library

### Reference Package/Project

- Install nuget package from nuget.org with `dotnet add package dymaptic.Blazor.GIS.API.Core`
  OR
- Download and add a package reference to the `/packages/dymaptic.Blazor.GIS.API.Core.1.0.x.nupkg` file
  OR
- download the source code and add a project reference to `dymaptic.Blazor.Api`.

### Reference Scripts and Styles

- Add the following lines to the `head` element of your `_Layout.cshtml` (Blazor Server) or `index.html` (Blazor Wasm or Maui Blazor Hybrid)

```html
    <link href="_content/dymaptic.Blazor.GIS.API.Core"/>
    <link href="https://js.arcgis.com/4.24/esri/themes/light/main.css" rel="stylesheet">
```

### Setup API Key

- See [Security and authentication | Documentation | ArcGIS Developers](https://developers.arcgis.com/documentation/mapping-apis-and-services/security/) to learn how to obtain an ArcGIS API Key.
- If you want to inject your api key via login or some other custom route, add the following line to your `Program.cs` file, so you can add values to `IConfiguration`:

```csharp
builder.Configuration.AddInMemoryCollection();
```

- If you want to hard-code your API key, add the key/value `"ArcGISApiKey": "YOUR_API_KEY"` to an `appsettings.json `, `appsettings.development.json`, `secrets.json`, Azure Key Vault, or environment variable. Make sure that it is loaded into `IConfiguration` by your application. _NOTE_: it is never recommended to save an api key to a version control repository!

### Add Using Statements

Add using statements as necessary to `_Imports.razor`. Below is a complete list of namespaces:

```csharp
@using dymaptic.Blazor.GIS.API.Core
@using dymaptic.Blazor.GIS.API.Core.Components
@using dymaptic.Blazor.GIS.API.Core.Components.Geometries
@using dymaptic.Blazor.GIS.API.Core.Components.Layers
@using dymaptic.Blazor.GIS.API.Core.Components.Popups
@using dymaptic.Blazor.GIS.API.Core.Components.Renderers
@using dymaptic.Blazor.GIS.API.Core.Components.Symbols
@using dymaptic.Blazor.GIS.API.Core.Components.Views
@using dymaptic.Blazor.GIS.API.Core.Components.Widgets
@using dymaptic.Blazor.GIS.API.Core.Objects
```

### Add components to Razor Components/Pages

You should now be ready to directly reference `MapView` and other components in your own Razor Components.

For more information, read [Using the API](UsingTheAPI.md).

### Known Limitations/"Gotchas"

- All classes inheriting from `MapComponent`, implement `IAsyncDisposable`. If you use these components in Razor markdown,
  it handles disposal for you. However, there may be situations (e.g., adding a new graphic on the fly),
  where you want to instantiate one of these components in C# code. Be aware that if you do this, you need to call
  `DisposeAsync` yourself when you are done with the object.
- Directly calling `graphicLayer.Add(graphic)` or `MapView.Widgets.Add(widget)` does not work currently to register these components
  with the JavaScript API. Instead, use `graphicLayer.RegisterChildComponent(graphic)` or
  `MapView.RegisterChildComponent(widget)`.

## Build Requirements

For the Asp.NET projects, including the core library, you can run on the latest [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download).

For the Maui sample project, you need the latest [_preview_ of Visual Studio](https://visualstudio.microsoft.com/vs/preview/).

## Projects

### dymaptic.Blazor.GIS.API.Core

- The core logic library

### dymaptic.Blazor.GIS.API.Core.Sample.Shared

- A razor class library for sample applications
- All sample pages are based on the [ArcGIS for Javascript API Tutorials](https://developers.arcgis.com/javascript/latest/).

### dymaptic.Blazor.GIS.API.Core.Sample.Server

- Asp.NET Core Blazor Server application sample
- `dotnet run --project .\samples\dymaptic.Blazor.GIS.API.Core.Sample.Server\dymaptic.Blazor.GIS.API.Core.Sample.Server.csproj`
- Runs on kestrel or via IIS
- Serves pages via SignalR/Websockets
- Can be loaded with a `usersecrets` file to provide the ArcGIS Api Key.

### dymaptic.Blazor.GIS.API.Core.Sample.Wasm

- `dotnet run --project .\samples\dymaptic.Blazor.GIS.API.Core.Sample.Wasm\dymaptic.Blazor.GIS.API.Core.Sample.Wasm.csproj`
- Runs Blazor in Web Assembly on the client browser
- No safe storage for API key, users must input an api key or sign in from the browser

### dymaptic.Blazor.GIS.API.Core.Sample.Maui

- Cross-platform mobile and desktop application
- Should be run from Visual Studio Preview. Command Line support appears to be limited at this time.
- Android and Windows versions tested

### dymaptic.Blazor.GIS.API.Interactive (not included in open source repo)

- Extended application features

  - Custom renderers (e.g. image icons), see [Feature Layers (demo)](https://dy-blazor-samples-server.azurewebsites.net/feature-layers)
  - Custom popups (e.g. charts, tables), see [Popups (demo)](https://dy-blazor-samples-server.azurewebsites.net/popups)
  - Advanced widgets (e.g. sketch, track), see [Sketch Query (demo)](https://dy-blazor-samples-server.azurewebsites.net/sketch-query)
  - Custom layers (e.g. GeoJSON Layer), see [Projection (demo)](https://dy-blazor-samples-server.azurewebsites.net/projection)
  - Advanced event handling (e.g., pointer move, sketch events, search events), see above examples
  - GeometryEngine direct calls, see [Calculate Geometries (demo)](https://dy-blazor-samples-server.azurewebsites.net/calculate-geometries)
  - ArcGIS Rest direct calls, see [Demographic Data (demo)](https://dy-blazor-samples-server.azurewebsites.net/demographic-data)
- Please contact info@dymaptic.com to discuss licensing these advanced features!
