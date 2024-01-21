using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using AD.Mono.Pong.Engine.Core.Systems;

namespace AD.Mono.Pong.Engine.Core.Registries;

public interface IRegistry : ILoad, IUpdate, IRender, IUnload
{
    public string Name { get; }
    public int Id { get; }
    public IEntityRegistry EntityRegistry { get; }
    public ISystemRegistry SystemRegistry { get; }
}