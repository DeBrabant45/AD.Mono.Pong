using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.StateMachines;

public abstract class BaseAction : IAction
{
    protected IEntity Owner;
    protected IStateMachine StateMachine;

    public BaseAction(IEntity owner, IStateMachine machine)
    {
        Owner = owner;
        StateMachine = machine;
    }

    public abstract void Load();
    public abstract void DoAction();
}
