using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AD.Mono.Pong.Engine.Scenes;

public abstract class BaseScene : ILoad, IUpdate, IRender, IUnload
{
    private readonly int _index;
    private readonly ContentManager _contentManager;
    protected Registry Registry;
    private Texture2D _texture;

    protected BaseScene(int index, ContentManager contentManager)
    {
        _index = index;
        _contentManager = contentManager;
        // Create the Registry
            // Entity Factory
                // Create the Entities
                    // Create the Components 
    }

    public int Index => _index;

    public void Load()
    {
        //Registry.Load();
        _texture = _contentManager.Load<Texture2D>("Title");
    }

    public void Update(float deltaTime)
    {
        //Registry.Update(deltaTime);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        //Registry.Render(spriteBatch);
        spriteBatch.Draw(_texture, Vector2.One, Color.White);
    }

    public void Unload()
    {
        _contentManager.Unload();
    }
}
