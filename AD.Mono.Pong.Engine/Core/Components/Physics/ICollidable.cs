using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Core.Components.Physics;

public interface ICollidable
{
    void OnCollision(Rectangle collision);
}
