using AD.Mono.Pong.Engine.Core.Entities;
using Microsoft.Xna.Framework;
using System;

namespace AD.Mono.Pong.Engine.Core.Components.Physics;

public class Rigidbody : BaseComponent
{
    private Transform _transform;
    private Rectangle _body;
    private Vector2 _velocity;
    private BodyType _bodyType;

    public Rigidbody(IEntity owner)
        : base(owner)
    {

    }

    public event Action<IEntity> OnCollision;

    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    public int Height() => _body.Height;

    public int Width() => _body.Width;

    public int XPosition() => _body.X;

    public int YPosition() => _body.Y;

    public int Center() => YPosition() + Height() / 2;

    public Rectangle Body => _body;

    public override void Load()
    {
        _transform = Owner.GetComponent<Transform>();
        _body = new()
        {
            X = (int)_transform.Position.X,
            Y = (int)_transform.Position.Y,
            Width = (int)_transform.Size.X,
            Height = (int)_transform.Size.Y
        };
    }

    public void MovePosition(Vector2 velocity)
    {
        _body.Y += (int)Math.Ceiling(velocity.Y);
        _body.X += (int)Math.Ceiling(velocity.X);
    }

    public void MovePosition(Vector2 velocity, Vector2 bounds)
    {
        if (YPosition() + Height() > bounds.Y - 10 || YPosition() < 10)
        {
            velocity.Y = 0;
        }

        if (XPosition() < 0 || XPosition() > bounds.X + 10)
        {
            velocity.X = 0;
        }

        MovePosition(velocity);
    }

    public bool IsColliding(Rigidbody other)
    {
        if (other == null)
            return false;

        return Body.Intersects(other.Body);
    }

    public void SetXPosition(int x) => _body.X = x;

    public void SetYPosition(int y) => _body.Y = y;

    public override void Update(float deltaTime)
    {
        _transform.Position = new Vector2(_body.X, _body.Y);
    }

    public void OnCollisionTrigger(IEntity otherEntity)
    {
        OnCollision?.Invoke(otherEntity);
    }
}

public enum BodyType
{
    Static,
    Dynamic,
    Kinematic
}