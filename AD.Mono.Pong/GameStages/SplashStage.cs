using AD.Mono.Pong.Engine.Core.Registries;
using AD.Mono.Pong.Engine.Stages;
using System;

namespace AD.Mono.Pong.GameStages;

public class SplashStage : BaseStage
{
    private const string StageName = "Splash Stage";

    public SplashStage(int id, IRegistry registry, IStageManager stageManager) 
        : base(id, StageName, registry, stageManager)
    {

    }

    protected override void AddConditions()
    {
        throw new NotImplementedException();
    }
}
