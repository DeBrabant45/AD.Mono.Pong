using AD.Mono.Pong.Engine.Components;
using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core;

public interface IEntity : ILoad, IUpdate, IRender, IUnload
{
    public string Tag { get; }
    public bool IsActive { get; }
    public bool IsDestroyed { get; }
    public event Action<IEntity> OnDestroyed;
    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public bool RemoveComponent<TComponent>() where TComponent : class, IComponent;
    public void RemoveAllComponents();
    public bool HasComponent<TComponent>() where TComponent : class, IComponent;
    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent;
    public List<TComponent> GetComponents<TComponent>() where TComponent : class, IComponent;
    public void Destroy();
}
