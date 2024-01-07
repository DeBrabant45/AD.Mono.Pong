using AD.Mono.Pong.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Registries;

namespace AD.Mono.Pong.Entities.Factories.Ball;
public class BallProduction : IEntityProduction
{
    public IEntity Produce(IRegistry owner, ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var ball = new Entity("Ball", "Ball");
        ball.AddComponent<Transform>(new Transform(ball, position, new() { X = 10, Y = 10 }));
        ball.AddComponent<Rigidbody>(new Rigidbody(ball));
        ball.AddComponent<BallMovement>(new BallMovement(ball));
        ball.AddComponent<Sprite>(new Sprite(ball, content, deviceManager, "ball"));

        return ball;
    }
}
