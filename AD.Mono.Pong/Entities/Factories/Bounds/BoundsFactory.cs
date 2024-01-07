using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Bounds;

public class BoundsFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new BoundsProduction();
    }
}
