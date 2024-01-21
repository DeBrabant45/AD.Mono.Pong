using AD.Mono.Pong.Components;
using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Ball;
public class BallProduction : IEntityProduction
{
    public IEntity Produce(EntityCreationContext context)
    {
        var ball = new Entity(context.Registry, "Ball", "Ball");
        ball.AddComponent<Transform>(new Transform(ball, context.StartPosition, new() { X = 10, Y = 10 }));
        ball.AddComponent<Rigidbody>(new Rigidbody(ball));
        ball.AddComponent<BallMovement>(new BallMovement(ball));
        ball.AddComponent<Sprite>(new Sprite(ball, context.Content, context.DeviceManager, "ball"));

        return ball;
    }
}
