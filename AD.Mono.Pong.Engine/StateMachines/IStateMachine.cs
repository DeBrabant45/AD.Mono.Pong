using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.StateMachines;

public interface IStateMachine
{
    public void AddStates(List<IState> states);
    public void AddState(IState state);
    public void RemoveState(IState state);
    public void TransitionToState(IState state);
    public IState GetState<T>();
}