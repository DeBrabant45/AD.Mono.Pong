using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Registries;

namespace AD.Mono.Pong.Entities.Factories.Bounds;

internal class BoundsProduction : IEntityProduction
{
    public IEntity Produce(IRegistry owner, ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var bound = new Entity("Bounds", "Bound");
        bound.AddComponent<Transform>(new Transform(bound, position, new() { X = GameBounds.Width, Y = 100 }));
        bound.AddComponent<Rigidbody>(new Rigidbody(bound));
        bound.AddComponent<Sprite>(new Sprite(bound, content, deviceManager, "Bounds"));

        return bound;
    }
}
