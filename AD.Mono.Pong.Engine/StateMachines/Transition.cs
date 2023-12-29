namespace AD.Mono.Pong.Engine.StateMachines;

public class Transition : ITransition
{
    private IDecision _decision;
    private IState _trueState;
    private IState _falseState;

    public Transition(IDecision decision, IState trueState, IState falseState)
    {
        _decision = decision;
        _trueState = trueState;
        _falseState = falseState;
    }

    public IDecision Decision => _decision;

    public IState TrueSate => _trueState;

    public IState FalseSate => _falseState;

    public void Load() => _decision.Load();
}
