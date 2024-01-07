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
    public IEntity Produce(IRegistry owner, ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var paddle = new Entity("Paddle", "Paddle");
        paddle.AddComponent<Transform>(new Transform(paddle, position, new() { X = 20, Y = 100 }));
        paddle.AddComponent<Rigidbody>(new Rigidbody(paddle));
        paddle.AddComponent<PaddleMovement>(new PaddleMovement(paddle));
        paddle.AddComponent<Sprite>(new Sprite(paddle, content, deviceManager, "paddle"));

        return paddle;
    }
}
