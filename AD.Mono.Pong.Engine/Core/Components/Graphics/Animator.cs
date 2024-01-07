using AD.Mono.Pong.Engine.Core.Entities;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AD.Mono.Pong.Engine.Core.Components.Graphics;

public class Animator : BaseComponent, IRender
{
    public Animator(IEntity owner)
        : base(owner)
    {

    }

    public override void Load()
    {
        throw new NotImplementedException();
    }

    public override void Update(float deltaTime)
    {
        throw new NotImplementedException();
    }

    public void Render(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}
