using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Systems;

public class CollisionSystem : ISystem
{
    private IEntityRegistry _entityRegistry;

    public CollisionSystem(IEntityRegistry entityRegistry)
    {
        _entityRegistry = entityRegistry;
    }

    public void Load()
    {

    }

    public void Update(float deltaTime)
    {
        CheckCollisions(_entityRegistry.Entities);
    }

    public void CheckCollisions(IList<IEntity> entities)
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

    private Rigidbody GetRigidbody(IEntity entity)
    {
        var rigidbody = entity.GetComponent<Rigidbody>();
        if (rigidbody == null)
            return null;

        return rigidbody;
    }
}
