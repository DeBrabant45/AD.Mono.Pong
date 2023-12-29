using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.StateMachines;
using Microsoft.Xna.Framework.Graphics;

namespace AD.Mono.Pong.GameStates.MainMenu;

public class MainMenuState : BaseState, IRender
{
    private readonly Registry _registry;

    public MainMenuState(IStateMachine stateMachine, Registry registry) 
        : base(stateMachine)
    {
        _registry = registry;
    }

    protected override void AddActions()
    {

    }

    protected override void AddTransitions()
    {

    }

    public void Render(SpriteBatch spriteBatch)
    {

    }
}
