using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.Core.Registries;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Entities;

public interface IEntity : ILoad, IUpdate, IRender, IUnload
{
    public string Name { get; }
    public int Id { get; }
    public string Tag { get; }
    public bool IsActive { get; }
    public bool IsDestroyed { get; }
    public IRegistry Registry { get; }
    public event Action<IEntity> OnDestroyed;
    public void TransferOwnership(IRegistry registry);
    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public bool RemoveComponent<TComponent>() where TComponent : class, IComponent;
    public void RemoveAllComponents();
    public bool HasComponent<TComponent>() where TComponent : class, IComponent;
    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent;
    public List<TComponent> GetComponents<TComponent>() where TComponent : class, IComponent;
    public void Destroy();
}
