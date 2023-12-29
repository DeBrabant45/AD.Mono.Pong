using AD.Mono.Pong.Engine.Systems;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core;

public class Registry : IRegistry
{
    private readonly IList<IEntity> _entities;
    private readonly IList<ISystem> _systems;

    public Registry(IList<IEntity> entities, IList<ISystem> systems)
    {
        _entities = entities;
        _systems = systems;
    }

    public IList<IEntity> Entities => _entities;

    public IList<ISystem> Systems => _systems;

    public void AddEntity(IEntity entity) => _entities.Add(entity);

    public void RemoveEntity(IEntity entity) => _entities.Remove(entity);

    public void AddSystem(ISystem system) => _systems.Add(system);

    public void RemoveSystem(ISystem system) => _systems.Remove(system);

    public void Load()
    {
        foreach (var entity in _entities)
        {
            entity.Load();
        }
        foreach (var system in _systems)
        {
            system.Load(this);
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entities)
        {
            entity.Update(deltaTime);
        }
        foreach(var system in _systems)
        {
            system.Update(deltaTime);
        }
    }

    public void Render(SpriteBatch spriteBatch)
    {
        foreach (var entity in _entities)
        {
            entity.Render(spriteBatch);
        }
    }

    public void Unload()
    {
        foreach(var entity in _entities)
        {
            entity.Unload();
        }
    }
}
