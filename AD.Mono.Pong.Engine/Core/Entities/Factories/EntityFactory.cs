using AD.Mono.Pong.Engine.Core.Registries;
using AD.Mono.Pong.Engine.Core.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Engine.Core.Entities.Factories;

public abstract class EntityFactory : IEntityFactory
{
    public IEntity Create(EntityCreationContext creationContext)
    {
        var entityProduction = CreateProduction();
        return entityProduction.Produce(creationContext);
    }

    protected abstract IEntityProduction CreateProduction();
}

public record EntityCreationContext(IRegistry Registry,
                                    ContentManager Content,
                                    GraphicsDeviceManager DeviceManager,
                                    Vector2 StartPosition);
