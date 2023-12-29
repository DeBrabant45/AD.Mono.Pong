using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.StateMachines;

public abstract class BaseDecision : IDecision
{
    protected readonly IEntity Owner;

    public BaseDecision(IEntity owner)
    {
        Owner = owner;
    }

    public abstract void Load();
    public abstract bool Decide();
}
