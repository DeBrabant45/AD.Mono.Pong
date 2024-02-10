using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework.Graphics;

namespace AD.Mono.Pong.Engine.Core.Registries;

public class Registry : IRegistry
{
    private static int _idGenerator;
    private readonly int _id;
    private readonly string _name;
    private readonly IEntityRegistry _entityRegistry;
    private readonly ISystemRegistry _systemRegistry;

    public Registry(string name, IEntityRegistry entityRegistry, ISystemRegistry systemRegistry)
    {
        _id = _idGenerator++;
        _name = name;
        _entityRegistry = entityRegistry;
        _systemRegistry = systemRegistry;
    }

    public string Name => _name;
    public int Id => _id;
    public IEntityRegistry EntityRegistry => _entityRegistry;
    public ISystemRegistry SystemRegistry => _systemRegistry;

    public void Load()
    {
        _entityRegistry.Load();
        _systemRegistry.Load();
    }

    public void Render(SpriteBatch spriteBatch)
    {
        _entityRegistry.Render(spriteBatch);
    }

    public void Reset()
    {
        _entityRegistry.Reset();
    }

    public void Unload()
    {
        _entityRegistry.Unload();
    }

    public void Update(float deltaTime)
    {
        _entityRegistry.RemoveDestroyedEntities();
        _entityRegistry.Update(deltaTime);
        _systemRegistry.Update(deltaTime);
    }
}
