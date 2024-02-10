using AD.Mono.Pong.Engine.Core.LifeCycles;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Systems;

public interface ISystemRegistry : ILoad, IUpdate
{
    public void AddSystem(ISystem system);
    public void AddSystems(IList<ISystem> systems);
    public TSystem GetSystem<TSystem>() where TSystem : class, ISystem;
    public void RemoveSystem(ISystem system);
}