using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Bounds;

public class BoundsFactory : EntityFactory
{
    public override IEntityProduction CreateProduction()
    {
        return new BoundsProduction();
    }
}
