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
        Owner.OnCollision += HandleCollision;
    }

    public override void Update(float deltaTime)
    {
        float maxVelocity = 1.5f;
        ClampVelocity(maxVelocity);
        Move();
    }

    private void ClampVelocity(float maxVelocity)
    {
        _velocity.X = MathHelper.Clamp(_velocity.X, -maxVelocity, maxVelocity);
        _velocity.Y = MathHelper.Clamp(_velocity.Y, -maxVelocity, maxVelocity);
    }

    private void Move()
    {
        _rigidbody.MovePosition(new() { X = _velocity.X * _speed, Y = _velocity.Y * _speed });
    }

    public void HandleCollision(IEntity entity)
    {
        if (entity == null)
            return;

        PaddleBounce(entity);
        BoundsBounce(entity);
        Wall(entity);
    }

    private void PaddleBounce(IEntity entity)
    {
        if (!entity.Tag.Contains("Paddle"))
            return;

        _velocity.X *= -1;
        _velocity.Y *= 1.1f;
        Move();
    }

    private void BoundsBounce(IEntity entity)
    {
        if (entity.Tag != "Floor" && entity.Tag != "Ceiling")
            return;

        _velocity.Y *= -CalculateRandomBounce();
        Move();
    }

    private float CalculateRandomBounce()
    {
        return 1 + _random.Next(-100, 101) * 0.005f;
    }

    private void Wall(IEntity entity)
    {
        if (!entity.Tag.Contains("Wall"))
            return;

        Owner.Destroy();
    }
}