using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.Components;

public abstract class BaseComponent : IComponent
{
    protected readonly IEntity Owner;

    public BaseComponent(IEntity owner)
    {
        Owner = owner;
    }

    public virtual void Load() { }

    public virtual void Update(float deltaTime) { }
}
