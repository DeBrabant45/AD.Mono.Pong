using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Systems;

public class CollisionSystem
{
    public void CheckCollisions(List<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            var entityA = entities[i];
            var boundsA = GetCollisionBounds(entityA);
            for (int j = i + 1; j < entities.Count; j++)
            {
                var entityB = entities[j];
                var boundsB = GetCollisionBounds(entityB);
                if (boundsA.Intersects(boundsB))
                {
                    entityA.OnCollisionTrigger(entityB);
                    entityB.OnCollisionTrigger(entityA);
                }
            }
        }
    }

    private Rectangle GetCollisionBounds(IEntity entity)
    {
        var rigidbody = entity.GetComponent<Rigidbody>();
        return rigidbody.Body;
    }
}
