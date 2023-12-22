using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Paddle;

public class PaddleFactory : EntityFactory
{
    public override IEntityProduction CreateProduction()
    {
        return new PaddleProduction();
    }
}
