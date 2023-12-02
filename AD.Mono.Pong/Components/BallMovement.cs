using AD.Mono.Pong.Engine.Components;
using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using System;

namespace AD.Mono.Pong.Components;

public class BallMovement : BaseComponent
{
    private Rigidbody _rigidbody;
    private Vector2 _velocity;
    private float _speed = 15.0f;
    private Random _random;

    public BallMovement(IEntity owner) 
        : base(owner)
    {
        _random = new Random();
    }

    public override void Load()
    {
        _rigidbody = Owner.GetComponent<Rigidbody>();
        _velocity = new(1, 0.1f);
    }

    public override void Update(float deltaTime)
    {
        float maxVelocity = 1.5f;
        ClampVelocity(maxVelocity);

        _rigidbody.MovePosition(new() { X = _velocity.X * _speed, Y = _velocity.Y * _speed });
        HandleHorizontalCollision();
        HandleVerticalBounce();
    }

    private void ClampVelocity(float maxVelocity)
    {
        _velocity.X = MathHelper.Clamp(_velocity.X, -maxVelocity, maxVelocity);
        _velocity.Y = MathHelper.Clamp(_velocity.Y, -maxVelocity, maxVelocity);
    }

    private float CalculateRandomBounce()
    {
        return 1 + _random.Next(-100, 101) * 0.005f;
    }

    private void HandleHorizontalCollision()
    {
        if (_rigidbody.XPosition() < 0)
        {
            _rigidbody.SetXPosition(1);
            _velocity.X *= -1;
        }
        else if (_rigidbody.XPosition() > GameBounds.Width)
        {
            _rigidbody.SetXPosition(GameBounds.Width - 1);
            _velocity.X *= -1;
        }
    }

    private void HandleVerticalBounce()
    {
        if (_rigidbody.YPosition() < 0 + 10)
        {
            _rigidbody.SetYPosition(10 + 1);
            _velocity.Y *= -CalculateRandomBounce();
        }
        else if (_rigidbody.YPosition() > GameBounds.Height - 10)
        {
            _rigidbody.SetYPosition(GameBounds.Height - 11);
            _velocity.Y *= -CalculateRandomBounce();
        }
    }
}