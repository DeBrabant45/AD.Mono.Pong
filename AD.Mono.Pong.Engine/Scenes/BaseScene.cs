using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.Core.Registries;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AD.Mono.Pong.Engine.Scenes;

public abstract class BaseScene : ILoad, IUpdate, IRender, IUnload
{
    private readonly int _index;
    private readonly ContentManager _contentManager;
    private readonly SceneHandler _sceneHandler;
    protected Registry Registry;
    public event Action<BaseScene> OnSceneChange;

    protected BaseScene(int index, SceneHandler sceneHandler, ContentManager contentManager)
    {
        _index = index;
        _sceneHandler = sceneHandler;
        _contentManager = contentManager;
        // Create the Registry
            // Entity Factory
                // Create the Entities
                    // Create the Components 
    }

    public int Index => _index;

    public void Load()
    {
        Registry.Load();
    }

    public void Update(float deltaTime)
    {
        Registry.Update(deltaTime);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        Registry.Render(spriteBatch);
    }

    public void Unload()
    {
        _contentManager.Unload();
    }


}
