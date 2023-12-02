using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Components.Physics;

public interface ICollidable
{
    void OnCollision(Rectangle collision);
}
