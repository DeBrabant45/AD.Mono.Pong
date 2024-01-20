using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Bounds;

public class BoundsProduction : IEntityProduction
{
    public IEntity Produce(EntityCreationContext context)
    {
        var bound = new Entity("Bounds", "Bound");
        bound.AddComponent<Transform>(new Transform(bound, context.StartPosition, new() { X = GameBounds.Width, Y = 100 }));
        bound.AddComponent<Rigidbody>(new Rigidbody(bound));
        bound.AddComponent<Sprite>(new Sprite(bound, context.Content, context.DeviceManager, "Bounds"));

        return bound;
    }
}
