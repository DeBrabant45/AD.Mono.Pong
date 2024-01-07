using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Ball;

public class BallFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new BallProduction();
    }
}
