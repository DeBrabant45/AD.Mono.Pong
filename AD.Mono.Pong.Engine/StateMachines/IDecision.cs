using AD.Mono.Pong.Engine.Core.LifeCycles;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IDecision : ILoad
{
    public bool Decide();
}