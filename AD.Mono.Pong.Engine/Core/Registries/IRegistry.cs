using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Entities.Factories;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Registries;

public interface IRegistry : ILoad, IUpdate, IRender, IUnload
{
    public string Name { get; }
    public int Id { get; }
    IList<IEntity> Entities { get; }
    IList<ISystem> Systems { get; }
    public IEntity CreateEntity(IEntityFactory entityFactory, Vector2 position);
    public IList<IEntity> CreateEntities(IList<Tuple<IEntityFactory, Vector2>> entityFactories);
    public void AddEntity(IEntity entity);
    public void AddEntities(IList<IEntity> entities);
    public void RemoveEntity(IEntity entity);
    public void RemoveEntities(IList<IEntity> entities);
    public IEntity FindEntityByName(string name);
    public IEntity FindEntityByTag(string tag);
    public IEntity FindEntityById(int id);
    public void DestroyAllEntities();
    public void AddSystem(ISystem system);
    public void RemoveSystem(ISystem system);
}