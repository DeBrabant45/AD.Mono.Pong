namespace AD.Mono.Pong.Engine.Core.Entities.Factories;

public interface IEntityFactory
{
    public IEntity Create(EntityCreationContext creationContext);
}