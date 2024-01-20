using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Registries;
using AD.Mono.Pong.Engine.Core.Registries.Factories;
using AD.Mono.Pong.Engine.Core.Systems;
using AD.Mono.Pong.Entities.Factories.Ball;
using AD.Mono.Pong.Entities.Factories.Bounds;
using AD.Mono.Pong.Entities.Factories.Paddle;
using AD.Mono.Pong.Entities.Factories.Wall;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace AD.Mono.Pong.Registries.Factories;

public class PlayStageProduction : IRegistryProduction
{
    private EntityFactory _entityFactory;

    public IRegistry Produce(ContentManager content, GraphicsDeviceManager deviceManager)
    {
        var name = "Play Stage Registry";
        var registry = new Registry(name, content, deviceManager);
        var userInputSystem = new UserInputSystem(PlayerIndex.One);

        _entityFactory = new PaddleFactory();

        var playerPaddle = _entityFactory.Create(
            new(registry, content, deviceManager, 
            new() { X = 0 + 10, Y = GameBounds.Height / 2 },
            userInputSystem));

        _entityFactory = new BallFactory();
        var ball = _entityFactory.Create(new(registry, content, deviceManager, new() { X = GameBounds.Width / 2, Y = 200 }));

        _entityFactory = new BoundsFactory();
        var floor = _entityFactory.Create(new(registry, content, deviceManager, new() { Y = GameBounds.Height - 10 }));
        var ceiling = _entityFactory.Create(new(registry, content, deviceManager, new() { Y = -90 }));

        _entityFactory = new WallFactory();
        var leftWall = _entityFactory.Create(new(registry, content, deviceManager, new() { X = GameBounds.Width - 2 }));
        var rightWall = _entityFactory.Create(new(registry, content, deviceManager, new() { X = -18 }));

        registry.AddEntities(new List<IEntity>
        {
            playerPaddle,
            floor, 
            ceiling,
            ball,
            leftWall, 
            rightWall
        });
        registry.AddSystems(new List<ISystem>
        {
            new CollisionSystem(registry),
            userInputSystem
        });

        return registry;
    }
}
