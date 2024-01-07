using AD.Mono.Pong.Engine.Core.LifeCycles;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Stages;

public interface IStageManager : ILoad, IUnload, IUpdate, IRender
{
    public void AddStage(IList<IStage> stage);
    public void AddStage(IStage stage);
    public IStage FindStageByLowestId();
    public IStage FindStage<TStage>();
    public IStage FindStageById(int id);
    public IStage FindStageByName(string name);
    public void GoToStage(IStage nextStage);
    public void GoToStage(int stageId);
    public void GoToStage(string stageName);
    public void RemoveStage(IStage stage);
}