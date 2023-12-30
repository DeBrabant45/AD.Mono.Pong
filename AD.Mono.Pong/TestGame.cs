using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using AD.Mono.Pong.Engine.StateMachines;
using AD.Mono.Pong.Engine.Systems;
using AD.Mono.Pong.Factories.Ball;
using AD.Mono.Pong.Factories.Bounds;
using AD.Mono.Pong.Factories.Paddle;
using AD.Mono.Pong.Factories.Wall;
using AD.Mono.Pong.GameStates;
using AD.Mono.Pong.GameStates.MainMenu;
using AD.Mono.Pong.GameStates.Play;
using AD.Mono.Pong.GameStates.Splash;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AD.Mono.Pong;
public class TestGame : Game
{
    private readonly Registry _registry;
    private readonly EntityFactory _entityFactory;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly GameStateMachine _gameStateMachine;

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = GameBounds.Width,
            PreferredBackBufferHeight = GameBounds.Height
        };
        IsMouseVisible = true;

        _entityFactory = new PaddleFactory();
        var leftPaddle = _entityFactory.Create(Content, _graphics, new() { X = GameBounds.Width - 30, Y = GameBounds.Height / 2 });
        var rightPaddle = _entityFactory.Create(Content, _graphics, new() { X = 0 + 10, Y = GameBounds.Height / 2 });

        _entityFactory = new BallFactory();
        var ball = _entityFactory.Create(Content, _graphics, new() { X = GameBounds.Width / 2, Y = 200 });

        _entityFactory = new BoundsFactory();
        var floor = _entityFactory.Create(Content, _graphics, new() { Y = GameBounds.Height - 10 });
        var ceiling = _entityFactory.Create(Content, _graphics, new() { Y = -90 });

        _entityFactory = new WallFactory();
        var leftWall = _entityFactory.Create(Content, _graphics, new() { X = GameBounds.Width - 2 });
        var rightWall = _entityFactory.Create(Content, _graphics, new() { X = -18 });

        _registry = new(
            new List<IEntity>()
            {
                leftPaddle,
                rightPaddle,
                ball,
                ceiling,
                floor,
                rightWall,
                leftWall
            },
            new List<ISystem>()
            {
                new CollisionSystem(),
            });

        _gameStateMachine = new();
        _gameStateMachine.AddStates(new List<IState> 
        { 
            new PlayState(_gameStateMachine, _registry),
        });
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _gameStateMachine.Load();
    }

    protected override void UnloadContent()
    {
        _gameStateMachine.Unload();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _gameStateMachine.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _gameStateMachine.Render(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

public class GameBounds
{
    public static readonly int Width = 1280;
    public static readonly int Height = 720;
}
