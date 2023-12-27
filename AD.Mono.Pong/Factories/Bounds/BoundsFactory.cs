using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Bounds;

public class BoundsFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new BoundsProduction();
    }
}
