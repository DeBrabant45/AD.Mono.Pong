using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.Core.Registries;

namespace AD.Mono.Pong.Engine.Core.Systems;

public interface ISystem : IUpdate
{
    public void Load(IRegistry registry);
}
