using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

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
        var newEntity = entityFactory.Create(new(this, _contentManager, _graphicsDeviceManager, position));
        AddEntity(newEntity);
        return newEntity;
    }

    public IList<IEntity> CreateEntities(IList<Tuple<IEntityFactory, Vector2>> entityFactories)
    {
        var entities = new List<IEntity>();
        for (int i = 0; i < entityFactories.Count; i++)
        {
            var factory = entityFactories[i];
            var newEntity = factory.Item1.Create(new(this, _contentManager, _graphicsDeviceManager, factory.Item2));
            AddEntity(newEntity);
            entities.Add(newEntity);
        }
        return entities;
    }

    public void AddEntity(IEntity entity) => _entities.Add(entity);

    public void AddEntities(IList<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i] is null)
                continue;

            AddEntity(entities[i]);
        }
    }

    public void RemoveEntity(IEntity entity) => _entities.Remove(entity);

    public void RemoveEntities(IList<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i] is null)
                continue;

            RemoveEntity(entities[i]);
        }
    }

    public void RemoveEntities(IList<int> ids)
    {
        var foundEntities = FindEntitiesById(ids);
        if (foundEntities.Count <= 0)
            return;

        RemoveEntities(foundEntities);
    }

    public void RemoveEntity(int id)
    {
        var entity = FindEntityById(id);
        if (entity is null)
            return;
      
        RemoveEntity(entity);
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

    public IList<IEntity> FindEntitiesById(IList<int> ids)
    {
        var entities = new List<IEntity>();
        for (int i = 0; i < _entities.Count; i++)
        {
            for (int j = 0; j < ids.Count; j++)
            {
                if (_entities[i].Id != ids[j])
                    continue;

                entities.Add(_entities[i]);
            }
        }
        return entities;
    }

    public void DestroyAllEntities()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Destroy();
        }
    }

    public void AddSystem(ISystem system) => _systems.Add(system);

    public void AddSystems(IList<ISystem> systems)
    {
        for(int i = 0;i < systems.Count;i++)
        {
            if (systems[i] is null)
                continue;

            AddSystem(systems[i]);
        }
    }

    public void RemoveSystem(ISystem system) => _systems.Remove(system);

    public TSystem FindSystem<TSystem>() where TSystem : class, ISystem
    {
        return _systems.OfType<TSystem>().FirstOrDefault() ??
            throw new InvalidOperationException($"{typeof(TSystem)} does not exist on systems list!");
    }

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
            _systems[i].Load();
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
        RemoveDestroyedEntities();
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

    private void RemoveDestroyedEntities()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            if (!_entities[i].IsDestroyed)
                continue;

            RemoveEntity(_entities[i]);
        }
    }
}
