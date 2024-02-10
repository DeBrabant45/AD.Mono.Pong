using AD.Mono.Pong.Engine.Core.Entities;

namespace AD.Mono.Pong.Engine.Core.Components;

public abstract class BaseComponent : IComponent
{
    protected readonly IEntity Owner;

    public BaseComponent(IEntity owner)
    {
        Owner = owner;
    }

    public virtual void Load() { }

    public virtual void Reset() { }

    public virtual void Update(float deltaTime) { }
}
