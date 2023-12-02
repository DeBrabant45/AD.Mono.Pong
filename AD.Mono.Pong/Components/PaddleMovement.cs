using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using System;

namespace AD.Mono.Pong.Components;

public class PaddleMovement : BaseComponent
{
    private Random Rand = new Random();
    private Rigidbody _rigidbody;

    public PaddleMovement(IEntity owner) 
        : base(owner)
    {

    }

    public override void Load()
    {
        _rigidbody = Owner.GetComponent<Rigidbody>();
    }

    public override void Update(float deltaTime)
    {
        Move(deltaTime);
    }

    private void Move(float deltaTime)
    {
        int randomVelocity = Rand.Next(55, 120);
        _rigidbody.MovePosition(new() { Y = randomVelocity * deltaTime }, new() { Y = GameBounds.Height, X = GameBounds.Width });
    }
}