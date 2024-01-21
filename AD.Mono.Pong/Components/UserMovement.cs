using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong.Components;

public class UserMovement : BaseComponent
{
    private float _movementSpeed;
    private Rigidbody _rigidbody;
    private UserInputSystem _userInput;

    public UserMovement(IEntity owner) 
        : base(owner)
    {
        _movementSpeed = 300f;
    }

    public override void Load()
    {
        _rigidbody = Owner.GetComponent<Rigidbody>();
        _userInput = Owner.Registry.FindSystem<UserInputSystem>();
    }

    public override void Update(float deltaTime)
    {
        if (_userInput.IsKeyDown(Keys.W))
        {
            MoveVertically(-_movementSpeed * deltaTime);
        }
        if (_userInput.IsKeyDown(Keys.S))
        {
            MoveVertically(_movementSpeed * deltaTime);
        }
    }

    private void MoveVertically(float velocity)
    {
        _rigidbody.MovePosition(new() { Y = velocity });
    }
}
