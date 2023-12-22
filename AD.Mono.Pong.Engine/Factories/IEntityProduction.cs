using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace AD.Mono.Pong.Engine.Factories;

public interface IEntityProduction
{
    public IEntity Produce(ContentManager content, GraphicsDeviceManager deviceManager, Vector2 position);
}
