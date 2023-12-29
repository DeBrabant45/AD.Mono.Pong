using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface ITransition : ILoad
{
    public IDecision Decision { get; }
    public IState TrueSate { get; }
    public IState FalseSate { get; }
}
