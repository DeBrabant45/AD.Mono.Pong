using AD.Mono.Pong.Engine.Core.LifeCycles;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace AD.Mono.Pong.Engine.Scenes;

public class SceneHandler : ILoad, IUpdate, IRender, IUnload
{
    private readonly List<BaseScene> _scenes;
    private BaseScene _currentScene;

    public SceneHandler(List<BaseScene> scenes)
    {
        _scenes = scenes;
        _currentScene = _scenes.FirstOrDefault();
        _scenes.ForEach(scene =>
        {
            if (_currentScene.Index > scene.Index)
                return;

            _currentScene = scene;
        });
    }

    public void Load()
    {
        _currentScene.Load();
    }

    public void Unload()
    {
        _currentScene.Unload();
    }

    public void Update(float gameTime)
    {
        _currentScene.Update(gameTime);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        _currentScene.Render(spriteBatch);
    }
}