using AD.Mono.Pong.Engine.Core;
using AD.Mono.Pong.Engine.StateMachines;
using Microsoft.Xna.Framework.Graphics;

namespace AD.Mono.Pong.GameStates;

public class GameStateMachine : StateMachine, IRender, IUnload
{
    public void Render(SpriteBatch spriteBatch)
    {
        if (CurrentState is IRender renderableState)
        {
            renderableState.Render(spriteBatch);
        }
    }

    public override void TransitionToState(IState nextState)
    {
        if (nextState == RemainState)
            return;

        Unload();
        CurrentState = nextState;
    }

    public void Unload()
    {
        if (CurrentState is IUnload unloadableState)
        {
            unloadableState.Unload();
        }
    }
}
