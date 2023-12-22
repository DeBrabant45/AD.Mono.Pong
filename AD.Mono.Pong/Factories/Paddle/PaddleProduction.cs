using AD.Mono.Pong.Components;
using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Factories.Paddle;

public class PaddleProduction : IEntityProduction
{
    public IEntity Produce(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var paddle = new Entity("Paddle");
        paddle.AddComponent<Transform>(new Transform(paddle, position, new() { X = 20, Y = 100 }));
        paddle.AddComponent<Rigidbody>(new Rigidbody(paddle));
        paddle.AddComponent<PaddleMovement>(new PaddleMovement(paddle));
        paddle.AddComponent<Sprite>(new Sprite(paddle, content, deviceManager, "paddle"));

        return paddle;
    }
}
