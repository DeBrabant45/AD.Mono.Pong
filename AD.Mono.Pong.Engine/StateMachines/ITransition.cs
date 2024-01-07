using AD.Mono.Pong.Engine.Core.LifeCycles;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface ITransition : ILoad
{
    public IDecision Decision { get; }
    public IState TrueState { get; }
    public IState FalseState { get; }
}
