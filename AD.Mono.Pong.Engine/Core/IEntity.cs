using AD.Mono.Pong.Engine.Components;
using Microsoft.Xna.Framework;
using System;

namespace AD.Mono.Pong.Engine.Core;

public interface IEntity : ILoad, IUpdate, IRender
{
    public string Tag { get; }
    public bool IsActive { get; }
    public GraphicsDeviceManager GraphicsDeviceManager { get; }
    public event Action<IEntity> OnCollision;
    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent;
    public void OnCollisionTrigger(IEntity otherEntity);
    public void Destroy();
}
