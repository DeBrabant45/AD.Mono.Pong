using AD.Mono.Pong.Engine.Core.LifeCycles;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IAction : ILoad
{
    public void DoAction();
}