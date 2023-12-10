using AD.Mono.Pong.Components;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Scenes;
using AD.Mono.Pong.Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AD.Mono.Pong;
public class TestGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private List<IEntity> _entities;
    private CollisionSystem _collisionSystem = new();

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GameBounds.Width;
        _graphics.PreferredBackBufferHeight = GameBounds.Height;
        IsMouseVisible = true;

        //Todo: Move all of these into a factory
        var leftPaddle = new Entity("LeftPaddle", _graphics);
        leftPaddle.AddComponent<Transform>(new Transform(leftPaddle, new() { X = GameBounds.Width - 30, Y = GameBounds.Height / 2 }, new() { X = 20, Y = 100 }));
        leftPaddle.AddComponent<Rigidbody>(new Rigidbody(leftPaddle));
        //leftPaddle.AddComponent<PaddleMovement>(new PaddleMovement(leftPaddle));
        leftPaddle.AddComponent<Sprite>(new Sprite(leftPaddle, Content, "LeftPaddle"));

        var rightPaddle = new Entity("RightPaddle", _graphics);
        rightPaddle.AddComponent<Transform>(new Transform(rightPaddle, new() { X = 0 + 10, Y = GameBounds.Height / 2 }, new() { X = 20, Y = 100 }));
        rightPaddle.AddComponent<Rigidbody>(new Rigidbody(rightPaddle));
        rightPaddle.AddComponent<Sprite>(new Sprite(rightPaddle, Content, "RightPaddle"));

        var ball = new Entity("Ball", _graphics);
        ball.AddComponent<Transform>(new Transform(ball, new() { X = GameBounds.Width / 2, Y = 200 }, new() { X = 10, Y = 10 }));
        ball.AddComponent<Rigidbody>(new Rigidbody(ball));
        ball.AddComponent<BallMovement>(new BallMovement(ball));
        ball.AddComponent<Sprite>(new Sprite(ball, Content, "Ball"));

        var floor = new Entity("Floor", _graphics);
        floor.AddComponent<Transform>(new Transform(floor, new() { Y = GameBounds.Height - 10 }, new() { X = GameBounds.Width, Y = 100 }));
        floor.AddComponent<Rigidbody>(new Rigidbody(floor));
        floor.AddComponent<Sprite>(new Sprite(floor, Content, "Floor"));

        var ceiling = new Entity("Ceiling", _graphics);
        ceiling.AddComponent<Transform>(new Transform(ceiling, new() { Y = -90 }, new() { X = GameBounds.Width, Y = 100 }));
        ceiling.AddComponent<Rigidbody>(new Rigidbody(ceiling));
        ceiling.AddComponent<Sprite>(new Sprite(ceiling, Content, "Ceiling"));

        var leftWall = new Entity("LeftWall", _graphics);
        leftWall.AddComponent<Transform>(new Transform(leftPaddle, new() { X = GameBounds.Width - 2}, new() { X = 20, Y = GameBounds.Height }));
        leftWall.AddComponent<Rigidbody>(new Rigidbody(leftWall));
        leftWall.AddComponent<Sprite>(new Sprite(leftWall, Content, "LeftWall"));

        var rightWall = new Entity("RightWall", _graphics);
        rightWall.AddComponent<Transform>(new Transform(rightWall, new() { X = -18 }, new() { X = 20, Y = GameBounds.Height }));
        rightWall.AddComponent<Rigidbody>(new Rigidbody(rightWall));
        rightWall.AddComponent<Sprite>(new Sprite(rightWall, Content, "RightWall"));

        _entities = new()
        {
            leftPaddle,
            rightPaddle,
            ball,
            ceiling,
            floor,
            rightWall,
            leftWall
        };
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _entities.ForEach(e => { e.Load(); });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _entities.ForEach(e => { e.Update(deltaTime); });
        _collisionSystem.CheckCollisions(_entities);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _entities.ForEach(e => { e.Render(_spriteBatch); });
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

public class GameBounds
{
    public static int Width = 1280;
    public static int Height = 720;
}
