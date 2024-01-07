using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Wall;

public class WallFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new WallProduction();
    }
}
