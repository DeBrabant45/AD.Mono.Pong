using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.Registries;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Engine.Core.Entities.Factories;

public interface IEntityProduction
{
    public IEntity Produce(IRegistry owner, ContentManager contentent, GraphicsDeviceManager deviceManager, Vector2 position);
}
