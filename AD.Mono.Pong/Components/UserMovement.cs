using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework.Input;

namespace AD.Mono.Pong.Components;

public class UserMovement : BaseComponent
{
    private readonly UserInputSystem _userInput;
    private float _movementSpeed;
    private Rigidbody _rigidbody;

    public UserMovement(IEntity owner, UserInputSystem userInput) 
        : base(owner)
    {
        _userInput = userInput;
        _movementSpeed = 300f;
    }

    public override void Load()
    {
       _rigidbody = Owner.GetComponent<Rigidbody>();
    }

    public override void Update(float deltaTime)
    {
        if (_userInput.IsKeyDown(Keys.W))
        {
            Move(-_movementSpeed * deltaTime);
        }
        if (_userInput.IsKeyDown(Keys.S))
        {
            Move(_movementSpeed * deltaTime);
        }
    }

    private void Move(float velocity)
    {
        _rigidbody.MovePosition(new() { Y = velocity });
    }
}
