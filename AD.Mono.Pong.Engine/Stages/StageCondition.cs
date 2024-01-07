using AD.Mono.Pong.Engine.StateMachines;

namespace AD.Mono.Pong.Engine.Stages;

public class StageCondition : IStageCondition
{
    private readonly IDecision _decision;
    private readonly IStage _trueStage;
    private readonly IStage _falseStage;

    public StageCondition(IDecision decision, IStage trueStage, IStage falseStage)
    {
        _decision = decision;
        _trueStage = trueStage;
        _falseStage = falseStage;
    }

    public IDecision Decision => _decision;

    public IStage TrueStage => _trueStage;

    public IStage FalseStage => _falseStage;

    public void Load()
    {
        _decision.Load();
    }
}
