using AD.Mono.Pong.Components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Registries;

namespace AD.Mono.Pong.Entities.Factories.Paddle;

public class PaddleProduction : IEntityProduction
{
    public IEntity Produce(EntityCreationContext context)
    {
        var paddle = new Entity(context.Registry, "Paddle", "Paddle");
        paddle.AddComponent<Transform>(new Transform(paddle, context.StartPosition, new() { X = 20, Y = 100 }));
        paddle.AddComponent<Rigidbody>(new Rigidbody(paddle));
        paddle.AddComponent<Sprite>(new Sprite(paddle, context.Content, context.DeviceManager, "paddle"));
        paddle.AddComponent<UserMovement>(new UserMovement(paddle));

        return paddle;
    }
}
