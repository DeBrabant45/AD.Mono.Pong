using AD.Mono.Pong.Engine.Components;

namespace AD.Mono.Pong.Engine.Core;

public interface IEntity : ILoad, IUpdate, IRender
{
    public string Tag { get; }
    public bool IsActive { get; }
    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent;
    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent;
    public void Destroy();
}
