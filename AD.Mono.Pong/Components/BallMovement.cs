using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using Microsoft.Xna.Framework;
using System;

namespace AD.Mono.Pong.Components;

public class BallMovement : BaseComponent
{
    private Rigidbody _rigidbody;
    private Vector2 _velocity;
    private float _speed = 700.0f;
    private Random _random;
    private float _deltaTime;

    public BallMovement(IEntity owner) 
        : base(owner)
    {
        _random = new Random();
    }

    public override void Load()
    {
        _rigidbody = Owner.GetComponent<Rigidbody>();
        _velocity = new(1, 0.1f);
        _rigidbody.OnCollision += HandleCollision;
    }

    public override void Update(float deltaTime)
    {
        var maxVelocity = 1.5f;
        _deltaTime = deltaTime;
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
        _rigidbody.MovePosition(new() { X = _velocity.X * _speed * _deltaTime, Y = _velocity.Y * _speed * _deltaTime });
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
        if (!entity.Tag.Contains("Bounds"))
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