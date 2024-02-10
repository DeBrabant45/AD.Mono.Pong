using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Entities;
public interface IEntityRegistry : IUnload, ILoad, IUpdate, IRender, IReset
{
    public IList<IEntity> Entities { get; }
    public void AddEntities(IList<IEntity> entities);
    public void AddEntity(IEntity entity);
    public IList<IEntity> CreateEntities(IList<Tuple<IEntityFactory, Vector2>> entityFactories);
    public IEntity CreateEntity(IEntityFactory entityFactory, Vector2 position);
    public void DestroyAllEntities();
    public IList<IEntity> FindEntitiesById(IList<int> ids);
    public IEntity FindEntityById(int id);
    public IEntity FindEntityByName(string name);
    public IEntity FindEntityByTag(string tag);
    public void RemoveDestroyedEntities();
    public void RemoveEntities(IList<IEntity> entities);
    public void RemoveEntities(IList<int> ids);
    public void RemoveEntity(IEntity entity);
    public void RemoveEntity(int id);
}