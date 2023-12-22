using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Factories.Bounds;

internal class BoundsProduction : IEntityProduction
{
    public IEntity Produce(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var bound = new Entity("Bounds");
        bound.AddComponent<Transform>(new Transform(bound, position, new() { X = GameBounds.Width, Y = 100 }));
        bound.AddComponent<Rigidbody>(new Rigidbody(bound));
        bound.AddComponent<Sprite>(new Sprite(bound, content, deviceManager, "Bounds"));

        return bound;
    }
}
