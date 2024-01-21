using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Systems;

public interface ISystemRegistry
{
    public void AddSystem(ISystem system);
    public void AddSystems(IList<ISystem> systems);
    public TSystem GetSystem<TSystem>() where TSystem : class, ISystem;
    public void LoadSystems();
    public void RemoveSystem(ISystem system);
    public void UpdateSystems(float deltaTime);
}