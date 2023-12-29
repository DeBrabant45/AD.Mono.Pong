using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.StateMachines;

public abstract class BaseState : IState
{
    protected readonly IStateMachine StateMachine;
    protected List<ITransition> Transitions;
    protected List<IAction> Actions;

    public BaseState(IStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void Load()
    {
        AddActions();
        AddTransitions();
        Actions?.ForEach(action => action.Load());
        Transitions?.ForEach(transition => transition.Load());
    }

    protected abstract void AddActions();
    protected abstract void AddTransitions();

    public virtual void Update(float deltaTime)
    {
        DoActions();
        CheckTransitions();
    }

    public void DoActions()
    {
        if (Actions == null || Actions.Count <= 0)
            return;

        Actions.ForEach(action => action.DoAction());
    }

    public void CheckTransitions()
    {
        if (Transitions == null || Transitions.Count <= 0)
            return;

        Transitions.ForEach(transition =>
        {
            var decisionSucceeded = transition.Decision.Decide();
            if (decisionSucceeded)
            {
                StateMachine.TransitionToState(transition.TrueSate);
            }
            else
            {
                StateMachine.TransitionToState(transition.FalseSate);
            }
        });
    }
}
