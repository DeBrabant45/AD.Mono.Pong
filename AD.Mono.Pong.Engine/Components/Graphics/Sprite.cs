using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AD.Mono.Pong.Engine.Components.Graphics;

public class Sprite : BaseComponent, IRender
{
    private readonly string _textureName;
    private readonly ContentManager _contentManager;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    private Texture2D _texture;
    private Transform _transform;

    public Sprite(IEntity owner,
        ContentManager contentManager, 
        GraphicsDeviceManager graphicsDeviceManager,
        string textureName)
        : base(owner)
    {
        _textureName = textureName;
        _contentManager = contentManager;
        _graphicsDeviceManager = graphicsDeviceManager;
    }

    public override void Load()
    {
        //_texture = _contentManager.Load<Texture2D>(_textureName);
        _transform = Owner.GetComponent<Transform>();
        // ToDo: Remove and add real textures
        _texture = new Texture2D(_graphicsDeviceManager.GraphicsDevice, 1, 1);
        _texture.SetData(new Color[] { Color.White });
    }

    public void Render(SpriteBatch spriteBatch)
    {
        DrawRectangle(spriteBatch, Color.White);
    }

    private void DrawRectangle(SpriteBatch spriteBatch, Color color)
    {
        var rect = new Rectangle((int)_transform.Position.X, (int)_transform.Position.Y, (int)_transform.Size.X, (int)_transform.Size.Y);
        spriteBatch.Draw(_texture, _transform.Position, rect,
            color * 1.0f,
            0, Vector2.Zero, 1.0f,
            SpriteEffects.None, 0.00001f);
    }
}
