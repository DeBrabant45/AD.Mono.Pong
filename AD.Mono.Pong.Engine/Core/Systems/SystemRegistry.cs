using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.Mono.Pong.Engine.Core.Systems;

public class SystemRegistry : ISystemRegistry
{
    private readonly IList<ISystem> _systems;

    public SystemRegistry()
    {
        _systems = new List<ISystem>();
    }

    public void AddSystem(ISystem system) => _systems.Add(system);

    public void AddSystems(IList<ISystem> systems)
    {
        for (int i = 0; i < systems.Count; i++)
        {
            if (systems[i] is null)
                continue;

            AddSystem(systems[i]);
        }
    }

    public void RemoveSystem(ISystem system) => _systems.Remove(system);

    public TSystem GetSystem<TSystem>() where TSystem : class, ISystem
    {
        return _systems.OfType<TSystem>().FirstOrDefault() ??
            throw new InvalidOperationException($"{typeof(TSystem)} does not exist on systems list!");
    }

    public void LoadSystems()
    {
        for (int i = 0; i < _systems.Count; i++)
        {
            _systems[i].Load();
        }
    }

    public void UpdateSystems(float deltaTime)
    {
        for (int i = 0; i < _systems.Count; i++)
        {
            _systems[i].Update(deltaTime);
        }
    }
}
