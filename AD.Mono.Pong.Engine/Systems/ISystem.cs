using AD.Mono.Pong.Engine.Core;

namespace AD.Mono.Pong.Engine.Systems;

public interface ISystem : IUpdate
{
    public void Load(IRegistry registry);
}
