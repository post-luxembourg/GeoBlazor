﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public class RasterStretchRenderer : Renderer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.RasterStretch;

    /// <summary>
    ///     The computeGamma automatically calculates best gamma value to render exported image based on empirical model. This is applicable to any stretch type when useGamma is true.
    /// </summary>
    public bool ComputeGamma { get; set; }

    /// <summary>
    ///    When Dynamic Range Adjustment is true, the statistics based on the current display extent are calculated as you zoom and pan around the image. This property only applies to images in 2D MapView.
    /// </summary>
    public bool DynamicRangeAdjustment { get; set; } = false;

    /// <summary>
    ///     The gamma values to be used if useGamma is set to true. Gamma refers to the degree of contrast between the mid-level gray values of a raster dataset. Gamma does not affect the black or white values in a raster dataset, only the middle values. By applying a gamma correction, you can control the overall brightness of a layer. Gamma stretching is only valid with the none, standard-deviation, and min-max stretch
    /// </summary>
    public int[]? Gamma { get; set; }

    /// <summary>
    ///     The outputMax denotes the output maximum, which is the highest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast stretched. The outputMax value ranges from 0-255.
    /// </summary>
    public int? OutputMax { get; set; }

    /// <summary>
    ///     The outputMin denotes the output minimum, which is the lowest pixel value. The outputMin and outputMax will set the range of values that will then be linearly contrast stretched. The outputMin value ranges from 0-255.
    /// </summary>
    public int? OutputMin { get; set; }

    /// <summary>
    ///     The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the pixel values along a histogram from the minimum and maximum values defined by their bit depth.
    /// </summary>
    public string? StretchType { get; set; }



}
