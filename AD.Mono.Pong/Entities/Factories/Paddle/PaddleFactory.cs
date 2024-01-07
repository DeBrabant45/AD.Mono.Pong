using AD.Mono.Pong.Engine.Core.Entities.Factories;

namespace AD.Mono.Pong.Entities.Factories.Paddle;

public class PaddleFactory : EntityFactory
{
    protected override IEntityProduction CreateProduction()
    {
        return new PaddleProduction();
    }
}
