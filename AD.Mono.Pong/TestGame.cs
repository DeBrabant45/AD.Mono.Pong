using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using AD.Mono.Pong.Engine.Systems;
using AD.Mono.Pong.Factories.Ball;
using AD.Mono.Pong.Factories.Bounds;
using AD.Mono.Pong.Factories.Paddle;
using AD.Mono.Pong.Factories.Wall;
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
    private CollisionSystem _collisionSystem = new();

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GameBounds.Width;
        _graphics.PreferredBackBufferHeight = GameBounds.Height;
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

        _registry = new(new List<IEntity>()
        {
            leftPaddle,
            rightPaddle,
            ball,
            ceiling,
            floor,
            rightWall,
            leftWall
        });
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _registry.Load();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _registry.Update(deltaTime);
        _collisionSystem.CheckCollisions(_registry.Entities);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _registry.Render(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

public class GameBounds
{
    public static int Width = 1280;
    public static int Height = 720;
}
