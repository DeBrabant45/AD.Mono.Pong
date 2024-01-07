using System;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.StateMachines;

public class StateMachine : IStateMachine
{
    protected List<IState> States;
    protected IState CurrentState;
    protected IState RemainState;

    public StateMachine()
    {

    }

    public StateMachine(List<IState> states)
    {
        States = states;
    }

    public void AddStates(List<IState> states) => States = states;

    public void AddState(IState state) => States.Add(state);

    public void RemoveState(IState state) => States.Remove(state);

    public void Load()
    {
        CurrentState = States[0];
        CurrentState.Load();
        RemainState = CurrentState;
    }

    public void Update(float deltaTime)
    {
        CurrentState.Update(deltaTime);
    }

    public IState GetState<T>()
    {
        foreach (var state in States)
        {
            if (state is T)
            {
                return state;
            }
        }

        throw new InvalidOperationException($"State of type {typeof(T)} not found.");
    }

    public virtual void TransitionToState(IState nextState)
    {
        if (nextState == RemainState)
            return;

        CurrentState = nextState;
        CurrentState.Load();
    }
}
