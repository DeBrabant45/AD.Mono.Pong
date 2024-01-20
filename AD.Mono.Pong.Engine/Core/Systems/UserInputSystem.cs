using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong.Engine.Core.Systems;

public class UserInputSystem : ISystem
{
    private KeyboardState _currentKeyboardState;
    private KeyboardState _previousKeyboardState;
    private GamePadState _currentGamePadState;
    private GamePadState _previousGamePadState;
    private readonly PlayerIndex _playerIndex;

    public UserInputSystem(PlayerIndex index)
    {
        _playerIndex = index;
    }

    public void Load()
    {

    }

    public void Update(float deltaTime)
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
        _previousGamePadState = _currentGamePadState;
        _currentGamePadState = GamePad.GetState(_playerIndex);
    }

    public bool IsKeyDown(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key);
    }

    public bool WasKeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
    }

    public bool IsButtonPressed(Buttons button)
    {
        return _currentGamePadState.IsButtonDown(button);
    }

    public bool WasButtonPressed(Buttons button)
    {
        return _currentGamePadState.IsButtonDown(button) && !_previousGamePadState.IsButtonDown(button);
    }
}
