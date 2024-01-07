using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace AD.Mono.Pong.Engine.Core.Registries.Factories;

public abstract class RegistryFactory : IRegistryFactory
{
    public IRegistry Create(ContentManager content, GraphicsDeviceManager deviceManager)
    {
        var registryProduction = CreateProduction();
        return registryProduction.Produce(content, deviceManager);
    }

    protected abstract IRegistryProduction CreateProduction();
}
