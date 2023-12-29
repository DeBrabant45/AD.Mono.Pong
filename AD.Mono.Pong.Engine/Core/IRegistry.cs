using AD.Mono.Pong.Engine.Systems;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core;
public interface IRegistry : ILoad, IUpdate, IRender, IUnload
{
    IList<IEntity> Entities { get; }
    IList<ISystem> Systems { get; }
    public void AddEntity(IEntity entity);
    public void RemoveEntity(IEntity entity);
    public void AddSystem(ISystem system);
    public void RemoveSystem(ISystem system);
}