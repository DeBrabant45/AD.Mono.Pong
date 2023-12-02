using AD.Mono.Pong.Components;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong;
public class TestGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IEntity _leftPaddle;
    private IEntity _rightPaddle;
    private IEntity _ball;

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = GameBounds.Width;
        _graphics.PreferredBackBufferHeight = GameBounds.Height;
        IsMouseVisible = true;

        _leftPaddle = new Entity("LeftPaddle", _graphics);
        _leftPaddle.AddComponent<Transform>(new Transform(_leftPaddle, new() { X= 0+10, Y = 150 }, new Vector2 { X = 20, Y = 100 }));
        _leftPaddle.AddComponent<Rigidbody>(new Rigidbody(_leftPaddle));
        _leftPaddle.AddComponent<PaddleMovement>(new PaddleMovement(_leftPaddle));
        _leftPaddle.AddComponent<Sprite>(new Sprite(_leftPaddle, Content, "Test"));

        _rightPaddle = new Entity("RightPaddle", _graphics);
        _rightPaddle.AddComponent<Transform>(new Transform(_rightPaddle, new() { X = 0 + 10, Y = 150 }, new Vector2 { X = 20, Y = 100 }));
        _rightPaddle.AddComponent<Transform>(new Rigidbody(_rightPaddle));
        _rightPaddle.AddComponent<Sprite>(new Sprite(_rightPaddle, Content, "Test"));

        _ball = new Entity("Ball", _graphics);
        _ball.AddComponent<Transform>(new Transform(_ball, new() { X = 1280 / 2, Y = 200}, new Vector2 { X = 10, Y = 10 }));
        _ball.AddComponent<Transform>(new Rigidbody(_ball));
        _ball.AddComponent<BallMovement>(new BallMovement(_ball));
        _ball.AddComponent<Sprite>(new Sprite(_ball, Content, "Test"));
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _leftPaddle.Load();
        _rightPaddle.Load();
        _ball.Load();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _leftPaddle.Update(deltaTime);
        _rightPaddle.Update(deltaTime);
        _ball.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        _leftPaddle.Render(_spriteBatch);
        _rightPaddle.Render(_spriteBatch);
        _ball.Render(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

public class GameBounds
{
    public static int Width = 1280;
    public static int Height = 720;
}
