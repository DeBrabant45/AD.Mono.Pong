using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.StateMachines;

namespace AD.Mono.Pong.Engine.Stages;

public interface IStageCondition : ILoad
{
    public IDecision Decision { get; }
    public IStage TrueStage { get; }
    public IStage FalseStage { get; }
}
