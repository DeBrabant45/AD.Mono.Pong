using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong.Engine;

public abstract class BaseGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RenderTarget2D _renderTarget;
    private Rectangle _renderScaleRectangle;
    private readonly int _designedResolutionWidth;
    private readonly int _designedResolutionHeight;
    private float _designedResolutionAspectRatio;

    public BaseGame(int width, int height)
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _designedResolutionWidth = width;
        _designedResolutionHeight = height;
        _designedResolutionAspectRatio = width / (float)height;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _designedResolutionWidth;
        _graphics.PreferredBackBufferHeight = _designedResolutionHeight;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
        _renderTarget = new RenderTarget2D(
            _graphics.GraphicsDevice,
            _designedResolutionWidth,
            _designedResolutionHeight,
            false,
            SurfaceFormat.Color,
            DepthFormat.None,
            0,
            RenderTargetUsage.DiscardContents);

        _renderScaleRectangle = GetScaleRectangle();
        base.Initialize();
    }

    private Rectangle GetScaleRectangle()
    {
        var variance = 0.5;
        var actualAspectRatio = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
        if (actualAspectRatio <= _designedResolutionAspectRatio)
        {
            var presentHeight = (int)(Window.ClientBounds.Width / _designedResolutionAspectRatio + variance);
            var barHeight = (Window.ClientBounds.Height - presentHeight) / 2;
            return new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
        }

        var presentWidth = (int)(Window.ClientBounds.Height * _designedResolutionAspectRatio + variance);
        var barWidth = (Window.ClientBounds.Width - presentWidth) / 2;
        return new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void UnloadContent()
    {

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _spriteBatch.End();
        _graphics.GraphicsDevice.SetRenderTarget(null);
        _graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1.0f, 0);
        _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
        _spriteBatch.Draw(_renderTarget, _renderScaleRectangle, Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
