﻿using AD.Mono.Pong.Engine.Core.Registries;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Stages;

public abstract class BaseStage : IStage
{
    private readonly int _id;
    private readonly string _name;
    protected readonly IRegistry Registry;
    protected readonly IStageManager Manager;
    protected IList<IStageCondition> Conditions;

    public BaseStage(int id, string name, IRegistry registry, IStageManager stageManager)
    {
        _id = id;
        _name = name;
        Registry = registry;
        Manager = stageManager;
    }

    public string Name => _name;

    public int Id => _id;
    // ToDo: How to handle Resetting of the Stage if Condition is met
    // ToDo: Add ability to pass persistent entities to next Stage
    // ToDo: Add Stage Components
    // ToDo: Look into UI Components
    // ToDo: Add Stage factories 
    protected abstract void AddConditions();

    public virtual void Load()
    {
        AddConditions();
        Registry.Load();
        LoadConditions();
    }

    private void LoadConditions()
    {
        for (int i = 0; i < Conditions.Count; i++)
        {
            Conditions[i].Load();
        }
    }

    public virtual void Render(SpriteBatch spriteBatch)
    {
        Registry.Render(spriteBatch);
    }

    public virtual void Unload()
    {
        Registry.Unload();
    }

    public virtual void Update(float deltaTime)
    {
        if (PauseGame.IsPaused)
            return;

        Registry.Update(deltaTime);
        CheckConditions();
    }

    public void CheckConditions()
    {
        if (Conditions == null || Conditions.Count <= 0)
            return;

        for (int i = 0; i < Conditions.Count; i++)
        {
            var decisionSucceeded = Conditions[i].Decision.Decide();
            if (!decisionSucceeded)
            {
                Manager.GoToStage(Conditions[i].FalseStage);
            }
            
            Manager.GoToStage(Conditions[i].TrueStage);
        }
    }

    public void Reset()
    {
        Registry.Reset();
    }
}

public class PauseGame
{
    private static bool _isPaused;
    public static bool IsPaused => _isPaused;
    public static void Pause() => _isPaused = true;
    public static void Unpause() => _isPaused = false;
}
