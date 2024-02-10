using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Registries;
using AD.Mono.Pong.Engine.Stages;
using AD.Mono.Pong.Engine.StateMachines;
using System.Collections.Generic;

namespace AD.Mono.Pong.GameStages;

public class PlayStage : BaseStage
{
    private const string StageName = "Play Stage";
    private IEntity _ball;
    private bool _isCountdownActive;
    private float _countdownTimer = 3f;

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

    public override void Load()
    {
        base.Load();
        _ball = Registry.EntityRegistry.FindEntityByName("Ball");
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        if (_ball is not null && _ball.IsDestroyed)
        {
            _isCountdownActive = true;
            PauseGame.Pause();
            Reset();
        }
        UpdatePauseCountdown(deltaTime);
    }

    private void UpdatePauseCountdown(float deltaTime)
    {
        if (!_isCountdownActive)
            return;

        _countdownTimer -= deltaTime;
        if (_countdownTimer <= 0)
        {
            PauseGame.Unpause();
            _isCountdownActive = false;
            _countdownTimer = 3f;
        }
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
