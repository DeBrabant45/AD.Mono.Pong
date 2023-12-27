using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Ball;

public class BallFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new BallProduction();
    }
}
