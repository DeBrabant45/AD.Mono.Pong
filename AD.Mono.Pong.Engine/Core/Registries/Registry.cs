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
        _entityRegistry.LoadEntities();
        _systemRegistry.LoadSystems();
    }

    public void Render(SpriteBatch spriteBatch)
    {
        _entityRegistry.RenderEntities(spriteBatch);
    }

    public void Unload()
    {
        _entityRegistry.Unload();
    }

    public void Update(float deltaTime)
    {
        _entityRegistry.UpdateEntities(deltaTime);
        _systemRegistry.UpdateSystems(deltaTime);
        _entityRegistry.RemoveDestroyedEntities();
    }
}
