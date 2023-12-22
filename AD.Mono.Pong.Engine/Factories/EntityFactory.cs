using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Engine.Factories;

public abstract class EntityFactory
{
    public IEntity Create(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position)
    {
        var entityProduction = CreateProduction();
        return entityProduction.Produce(content, deviceManager, position);
    }

    public abstract IEntityProduction CreateProduction();
}
