using AD.Mono.Pong.Engine.Core;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AD.Mono.Pong.Engine.Components.Graphics;

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
