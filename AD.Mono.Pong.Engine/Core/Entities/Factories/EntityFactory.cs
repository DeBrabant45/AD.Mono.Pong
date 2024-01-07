using AD.Mono.Pong.Engine.Core.Registries;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Engine.Core.Entities.Factories;

public abstract class EntityFactory : IEntityFactory
{
    public IEntity Create(IRegistry owner, ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var entityProduction = CreateProduction();
        return entityProduction.Produce(owner, content, deviceManager, position);
    }

    protected abstract IEntityProduction CreateProduction();
}
