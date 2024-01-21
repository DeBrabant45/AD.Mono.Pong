using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Wall;

public class WallProduction : IEntityProduction
{
    public IEntity Produce(EntityCreationContext context)
    {
        var wall = new Entity(context.Registry, "Wall", "Wall");
        wall.AddComponent<Transform>(new Transform(wall, context.StartPosition, new() { X = 20, Y = GameBounds.Height }));
        wall.AddComponent<Rigidbody>(new Rigidbody(wall));
        wall.AddComponent<Sprite>(new Sprite(wall, context.Content, context.DeviceManager, "Wall"));

        return wall;
    }
}
