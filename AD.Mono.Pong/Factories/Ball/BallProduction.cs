using AD.Mono.Pong.Components;
using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Factories.Ball;
public class BallProduction : IEntityProduction
{
    public IEntity Produce(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var ball = new Entity("Ball");
        ball.AddComponent<Transform>(new Transform(ball, position, new() { X = 10, Y = 10 }));
        ball.AddComponent<Rigidbody>(new Rigidbody(ball));
        ball.AddComponent<BallMovement>(new BallMovement(ball));
        ball.AddComponent<Sprite>(new Sprite(ball, content, deviceManager, "ball"));

        return ball;
    }
}
