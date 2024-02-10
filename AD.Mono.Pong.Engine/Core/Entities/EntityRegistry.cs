using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using System;

namespace AD.Mono.Pong.Engine.Core.Entities;

public class EntityRegistry : IEntityRegistry
{
    private readonly IList<IEntity> _entities;
    private readonly IList<IEntity> _removedEntities;
    private readonly ContentManager _contentManager;
    private readonly GraphicsDeviceManager _graphicsDeviceManager;
    private readonly SystemRegistry _systemRegistry;

    public EntityRegistry(ContentManager contentManager, GraphicsDeviceManager graphicsDevice, SystemRegistry systemRegistry)
    {
        _entities = new List<IEntity>();
        _removedEntities = new List<IEntity>();
        _contentManager = contentManager;
        _graphicsDeviceManager = graphicsDevice;
        _systemRegistry = systemRegistry;
    }

    public IList<IEntity> Entities => _entities;

    public IEntity CreateEntity(IEntityFactory entityFactory, Vector2 position)
    {
        var newEntity = entityFactory.Create(new(this, _systemRegistry, _contentManager, _graphicsDeviceManager, position));
        AddEntity(newEntity);
        return newEntity;
    }

    public IList<IEntity> CreateEntities(IList<Tuple<IEntityFactory, Vector2>> entityFactories)
    {
        var entities = new List<IEntity>();
        for (int i = 0; i < entityFactories.Count; i++)
        {
            var factory = entityFactories[i];
            var newEntity = factory.Item1.Create(new(this, _systemRegistry, _contentManager, _graphicsDeviceManager, factory.Item2));
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

    public void RemoveEntity(IEntity entity)
    {
        _entities.Remove(entity);
        _removedEntities.Add(entity);
    }

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

    public void RemoveDestroyedEntities()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            if (!_entities[i].IsDestroyed)
                continue;

            RemoveEntity(_entities[i]);
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
            _removedEntities.Add(_entities[i]);
        }
    }

    public void Load()
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Load();
        }
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Update(deltaTime);
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

    public void Reset()
    {
        ReAddRemovedEntities();
        for (int i = 0; i < _entities.Count; i++)
        {
            _entities[i].Reset();
        }
    }

    private void ReAddRemovedEntities()
    {
        AddEntities(_removedEntities);
    }
}
