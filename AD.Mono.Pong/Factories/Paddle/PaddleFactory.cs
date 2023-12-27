using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Paddle;

public class PaddleFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new PaddleProduction();
    }
}
