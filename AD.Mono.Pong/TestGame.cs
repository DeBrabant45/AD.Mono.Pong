using AD.Mono.Pong.Engine.Stages;
using AD.Mono.Pong.GameStages;
using AD.Mono.Pong.Registries.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong;

public class TestGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly IStageManager _stageManager;

    public TestGame()
    {
        Content.RootDirectory = "Content";
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = GameBounds.Width,
            PreferredBackBufferHeight = GameBounds.Height
        };
        IsMouseVisible = true;
        _stageManager = new StageManager();
        var playStageFactory = new PlayStageFactory();
        var playStageReg = playStageFactory.Create(Content, _graphics);
        var playStage = new PlayStage(1, playStageReg, _stageManager);
        _stageManager.AddStage(playStage);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _stageManager.Load();
    }

    protected override void UnloadContent()
    {
        _stageManager.Unload();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _stageManager.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _stageManager.Render(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

public class GameBounds
{
    public static readonly int Width = 1280;
    public static readonly int Height = 720;
}
