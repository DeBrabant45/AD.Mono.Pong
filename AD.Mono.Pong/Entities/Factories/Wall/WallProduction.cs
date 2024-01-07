using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Graphics;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Registries;


namespace AD.Mono.Pong.Entities.Factories.Wall;

public class WallProduction : IEntityProduction
{
    public IEntity Produce(IRegistry owner,ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var wall = new Entity("Wall", "Wall");
        wall.AddComponent<Transform>(new Transform(wall, position, new() { X = 20, Y = GameBounds.Height }));
        wall.AddComponent<Rigidbody>(new Rigidbody(wall));
        wall.AddComponent<Sprite>(new Sprite(wall, content, deviceManager, "Wall"));

        return wall;
    }
}
