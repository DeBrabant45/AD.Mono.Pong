using AD.Mono.Pong.Engine.Components.Graphics;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace AD.Mono.Pong.Factories.Wall;

public class WallProduction : IEntityProduction
{
    public IEntity Produce(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var wall = new Entity("Wall");
        wall.AddComponent<Transform>(new Transform(wall, position, new() { X = 20, Y = GameBounds.Height }));
        wall.AddComponent<Rigidbody>(new Rigidbody(wall));
        wall.AddComponent<Sprite>(new Sprite(wall, content, deviceManager, "Wall"));

        return wall;
    }
}
