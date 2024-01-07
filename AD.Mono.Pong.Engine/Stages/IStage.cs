using AD.Mono.Pong.Engine.Core.LifeCycles;

namespace AD.Mono.Pong.Engine.Stages;

public interface IStage : ILoad, IUnload, IUpdate, IRender
{
    public string Name { get; }
    public int Id { get; }
    public abstract void CheckConditions();
}
