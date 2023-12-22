using AD.Mono.Pong.Engine.Components.Physics;
using AD.Mono.Pong.Engine.Core;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Systems;

public class CollisionSystem
{
    public void CheckCollisions(List<IEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            var entityA = entities[i];
            var entityARigidBody = GetRigidbody(entityA);
            for (int j = i + 1; j < entities.Count; j++)
            {
                var entityB = entities[j];
                var entityBRigidBody = GetRigidbody(entityB);
                if (entityARigidBody == null || entityBRigidBody == null)
                    continue;

                if (!entityARigidBody.IsColliding(entityBRigidBody))
                    continue;

                entityARigidBody.OnCollisionTrigger(entityB);
                entityBRigidBody.OnCollisionTrigger(entityA);
            }
        }
    }

    private Rigidbody? GetRigidbody(IEntity entity)
    {
        var rigidbody = entity.GetComponent<Rigidbody>();
        if (rigidbody == null)
            return null;

        return rigidbody;
    }
}
