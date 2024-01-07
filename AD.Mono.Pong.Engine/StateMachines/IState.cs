using AD.Mono.Pong.Engine.Core.LifeCycles;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IState : ILoad, IUpdate
{
    public abstract void DoActions();
    public abstract void CheckTransitions();
}
