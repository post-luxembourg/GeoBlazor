---
layout: default
title: PopupOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## PopupOptions Class

A collection of options to define when creating a Popup.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">ArcGIS JS API</a>

```csharp
public class PopupOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PopupOptions
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Objects.PopupDockOptions,dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements)'></a>

## PopupOptions(PopupDockOptions, PopupVisibleElements) Constructor

Creates a new PopupOptions

```csharp
public PopupOptions(dymaptic.GeoBlazor.Core.Objects.PopupDockOptions? dockOptions=null, dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements? visibleElements=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Objects.PopupDockOptions,dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements).dockOptions'></a>

`dockOptions` [PopupDockOptions](dymaptic.GeoBlazor.Core.Objects.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Objects.PopupDockOptions')

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.

<a name='dymaptic.GeoBlazor.Core.Objects.PopupOptions.PopupOptions(dymaptic.GeoBlazor.Core.Objects.PopupDockOptions,dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements).visibleElements'></a>

`visibleElements` [PopupVisibleElements](dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements')

The visible elements that are displayed within the widget.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.PopupOptions.DockOptions'></a>

## PopupOptions.DockOptions Property

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.

```csharp
public dymaptic.GeoBlazor.Core.Objects.PopupDockOptions DockOptions { get; set; }
```

#### Property Value
[PopupDockOptions](dymaptic.GeoBlazor.Core.Objects.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Objects.PopupDockOptions')

<a name='dymaptic.GeoBlazor.Core.Objects.PopupOptions.VisibleElements'></a>

## PopupOptions.VisibleElements Property

The visible elements that are displayed within the widget.

```csharp
public dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements VisibleElements { get; set; }
```

#### Property Value
[PopupVisibleElements](dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Objects.PopupVisibleElements')