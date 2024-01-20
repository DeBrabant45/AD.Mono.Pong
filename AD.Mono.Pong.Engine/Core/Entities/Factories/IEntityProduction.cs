namespace AD.Mono.Pong.Engine.Core.Entities.Factories;

public interface IEntityProduction
{
    public IEntity Produce(EntityCreationContext creationContext);
}
