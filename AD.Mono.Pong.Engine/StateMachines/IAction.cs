using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IAction : ILoad
{
    public void DoAction();
}