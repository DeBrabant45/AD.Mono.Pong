using AD.Mono.Pong.Engine.Core.Entities;
using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Core.Components;

public class Transform : BaseComponent
{
    private Vector2 _position;
    private Vector2 _size;
    private float _direction;

    public Transform(IEntity owner, Vector2 position, Vector2 size)
        : base(owner)
    {
        _position = position;
        _size = size;
    }

    public Vector2 Position { get => _position; set => _position = value; }
    public Vector2 Size { get => _size; set => _size = value; }
    public float Direction { get => _direction; set => _direction = value; }
}
