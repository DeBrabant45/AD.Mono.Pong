using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Stages;

public class StageManager : IStageManager
{
    private readonly IList<IStage> _stages;
    private IStage _currentStage;
    private IStage _remainStage;

    public StageManager()
    {
        _stages = new List<IStage>();
    }

    public void Load()
    {
        _currentStage = FindStageByLowestId();
        _currentStage.Load();
        _remainStage = _currentStage;
    }

    public IStage FindStageByLowestId()
    {
        if (_stages.Count <= 0)
            throw new InvalidOperationException($"List of Stages is Empty!");

        var mindId = int.MaxValue;
        IStage stageWithLowestId = null;
        foreach (var stage in _stages)
        {
            if (stage.Id < mindId)
            {
                mindId = stage.Id;
                stageWithLowestId = stage;
            }
        }
        return stageWithLowestId;
    }

    public void AddStage(IStage stage) => _stages.Add(stage);

    public void AddStage(IList<IStage> stage)
    {
        for (int i = 0; i < stage.Count; i++)
        {
            _stages.Add(stage[i]);
        }
    }

    public void RemoveStage(IStage stage) => _stages.Remove(stage);

    public void Render(SpriteBatch spriteBatch)
    {
        _currentStage.Render(spriteBatch);
    }

    public void Unload()
    {
        _currentStage.Unload();
    }

    public void Update(float deltaTime)
    {
        _currentStage.Update(deltaTime);
    }

    public void GoToStage(IStage nextStage)
    {
        if (nextStage == _remainStage)
            return;

        _currentStage = nextStage;
        LoadNewCurrentStage();
    }

    private void LoadNewCurrentStage()
    {
        _currentStage.Load();
        _currentStage = _remainStage;
    }

    public void GoToStage(int stageId)
    {
        _currentStage = FindStageById(stageId);
        LoadNewCurrentStage();
    }

    public IStage FindStageById(int stageId)
    {
        for (int i = 0; i < _stages.Count; i++)
        {
            if (stageId != _stages[i].Id)
                continue;

            return _stages[i];
        }

        throw new InvalidOperationException($"No Stage with {stageId} found.");
    }

    public void GoToStage(string stageName)
    {
        _currentStage = FindStageByName(stageName);
        LoadNewCurrentStage();
    }

    public IStage FindStageByName(string stageName)
    {
        for (int i = 0; i < _stages.Count; i++)
        {
            if (stageName != _stages[i].Name)
                continue;

            return _stages[i];
        }

        throw new InvalidOperationException($"No Stage with {stageName} found.");
    }

    public IStage FindStage<TStage>()
    {
        foreach (var stage in _stages)
        {
            if (stage is TStage)
                return stage;
        }

        throw new InvalidOperationException($"Stage of type {typeof(TStage)} not found.");
    }
}
