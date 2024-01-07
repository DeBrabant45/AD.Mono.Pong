using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Core.Registries.Factories;

public interface IRegistryProduction
{
    public IRegistry Produce(ContentManager content, GraphicsDeviceManager deviceManager);
}
