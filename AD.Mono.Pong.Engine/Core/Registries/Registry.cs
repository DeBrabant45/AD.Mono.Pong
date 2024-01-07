using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Registries;

public class Registry : IRegistry
{
    private static int _idGenerator;
    private readonly int _id;
    private readonly string _name;
    private readonly IList<IEntity> _entities;
    private readonly IList<ISystem> _systems;
    private readonly ContentManager _contentManager;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;

    public Registry(string name, ContentManager contentManager, GraphicsDeviceManager graphicsDevice)
    {
        _id = _idGenerator++;
        _name = name;
        _entities = new List<IEntity>();
        _systems = new List<ISystem>();
        _contentManager = contentManager;
        _graphicsDeviceManager = graphicsDevice;
    }

    public string Name => _name;

    public int Id => _id;

    public IList<IEntity> Entities => _entities;

    public IList<ISystem> Systems => _systems;

    public IEntity CreateEntity(IEntityFactory entityFactory, Vector2 position)
    {
        var newEntity = entityFactory.Create(this, _contentManager, _graphicsDeviceManager, position);
        _entities.Add(newEntity);
        return newEntity;
    }

    public IList<IEntity> CreateEntities(IList<Tuple<IEntityFactory, Vector2>> entityFactories)
    {
        var entities = new List<IEntity>();
        for (int i = 0; i < entityFactories.Count; i++)
        {
            var factory = entityFactories[i];
            var newEntity = factory.Item1.Create(this, _contentManager, _graphicsDeviceManager, factory.Item2);
            _entities.Add(newEntity);
            entities.Add(newEntity);
        }
        return entities;
    }

    public void AddEntity(IEntity entity) => _entities.Add(entity);

    public void AddEntities(IList<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            _entities.Add(entities[i]);
        }
    }

    public void RemoveEntity(IEntity entity) => _entities.Remove(entity);

    public void RemoveEntities(IList<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            _entities.Remove(entities[i]);
        }
    }

    public IEntity FindEntityByName(string name)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            if (_entities[i].Name != name)
                continue;

            return _entities[i];
        }

        return null;
    }

    public IEntity FindEntityByTag(string tag)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            if (_entities[i].Tag != tag)
                continue;

            return _entities[i];
        }

        return null;
    }

    public IEntity FindEntityById(int id)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            if (_entities[i].Id != id)
                continue;

            return _entities[i];
        }

        return null;
    }

    public void DestroyAllEntities()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Destroy();
        }
    }

    public void AddSystem(ISystem system) => _systems.Add(system);

    public void RemoveSystem(ISystem system) => _systems.Remove(system);

    public void Load()
    {
        LoadEntities();
        LoadSystems();
    }

    private void LoadEntities()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Load();
        }
    }

    private void LoadSystems()
    {
        for (int i = 0; i < _systems.Count; i++)
        {
            _systems[i].Load(this);
        }
    }

    public void Render(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Render(spriteBatch);
        }
    }

    public void Unload()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Unload();
        }
    }

    public void Update(float deltaTime)
    {

        UpdateEntities(deltaTime);
        UpdateSystems(deltaTime);
    }

    private void UpdateEntities(float deltaTime)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Update(deltaTime);
        }
    }

    private void UpdateSystems(float deltaTime)
    {
        for (int i = 0; i < _systems.Count; i++)
        {
            _systems[i].Update(deltaTime);
        }
    }
}
