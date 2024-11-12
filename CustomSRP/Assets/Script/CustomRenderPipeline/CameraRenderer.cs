
using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer
{
    const string bufferName = "Render Camera";
    CommandBuffer buffer = new CommandBuffer { name = bufferName };
    
    ScriptableRenderContext context;
    Camera camera;
    

    public void Render (ScriptableRenderContext context, Camera camera) 
    {
        this.context = context;
        this.camera = camera;

        Setup();
        DrawVisibleGeometry();
        Submit();
    }
    
    void DrawVisibleGeometry() 
    {
        {
            if (camera.clearFlags == CameraClearFlags.Skybox)
            {
                // DrawSkybox is obsolete
                context.DrawSkybox(camera);
            }
        }
        
        
    }
    
    void Submit() 
    {
        buffer.EndSample(bufferName);
        ExecuteBuffer();
        context.Submit();
    }
    
    void Setup() 
    {
        context.SetupCameraProperties(camera);
        buffer.ClearRenderTarget(true, true, camera.backgroundColor);
        buffer.BeginSample(bufferName);
        ExecuteBuffer();
    }
    
    void ExecuteBuffer() 
    {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }
}