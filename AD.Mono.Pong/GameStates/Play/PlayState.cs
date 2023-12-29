using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.StateMachines;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AD.Mono.Pong.GameStates.Play;

public class PlayState : BaseState, IUnload, IRender
{
    private readonly Registry _registry;

    public PlayState(IStateMachine stateMachine, Registry registry) 
        : base(stateMachine)
    {
        _registry = registry;
    }

    public override void Load()
    {
        base.Load();
        _registry.Load();
    }

    protected override void AddActions()
    {

    }

    protected override void AddTransitions()
    {
        Transitions = new List<ITransition>
        {
            new Transition
            (
                new TestDecision(),
                StateMachine.GetState<PlayState>(),
                StateMachine.GetState<PlayState>()
            ),
        };
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        _registry.Update(deltaTime);
    }

    public void Render(SpriteBatch spriteBatch)
    {
        _registry.Render(spriteBatch);
    }

    public void Unload()
    {
        _registry.Unload();
    }
}
