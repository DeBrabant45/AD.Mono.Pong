using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Core.Registries.Factories;

public interface IRegistryFactory
{
    public IRegistry Create(ContentManager content, GraphicsDeviceManager deviceManager);
}
