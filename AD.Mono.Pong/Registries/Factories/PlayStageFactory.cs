using AD.Mono.Pong.Engine.Core.Registries.Factories;

namespace AD.Mono.Pong.Registries.Factories;

public class PlayStageFactory : RegistryFactory
{
    protected override IRegistryProduction CreateProduction()
    {
        return new PlayStageProduction();
    }
}
