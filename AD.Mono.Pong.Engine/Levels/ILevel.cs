using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.Factories;
using AD.Mono.Pong.Engine.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Levels;

public interface ILevel : ILoad, IUnload, IUpdate, IRender
{
    public string Name { get; }
    public int Id { get; }
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
