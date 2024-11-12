using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline
{
    private CameraRenderer renderer = new CameraRenderer();
    
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        // throw new System.NotImplementedException();
    }

    protected override void Render(ScriptableRenderContext context, List<Camera> cameras)
    {
        for (int i = 0; i < cameras.Count; i++) 
        {
            renderer.Render(context, cameras[i]);
        } 
    }
}