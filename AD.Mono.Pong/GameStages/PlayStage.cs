using AD.Mono.Pong.Engine.Core.Registries;
using AD.Mono.Pong.Engine.Stages;
using AD.Mono.Pong.Engine.StateMachines;
using System.Collections.Generic;

namespace AD.Mono.Pong.GameStages;

public class PlayStage : BaseStage
{
    private const string StageName = "Play Stage";

    public PlayStage(int id, IRegistry registry, IStageManager stageManager)
        : base(id, StageName, registry, stageManager)
    {

    }

    protected override void AddConditions()
    {
        Conditions = new List<IStageCondition>
        {
            new StageCondition(new TestDecision(), Manager.FindStage<PlayStage>(), Manager.FindStage<PlayStage>()),
        };
    }
}

public class TestDecision : IDecision
{
    public bool Decide()
    {
        return false;
    }

    public void Load()
    {

    }
}
