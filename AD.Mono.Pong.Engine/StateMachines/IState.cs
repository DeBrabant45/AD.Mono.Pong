using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IState : ILoad, IUpdate
{
    public abstract void DoActions();
    public abstract void CheckTransitions();
}
