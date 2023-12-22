﻿using AD.Mono.Pong.Engine.Factories;

namespace AD.Mono.Pong.Factories.Wall;

public class WallFactory : EntityFactory
{
    public override IEntityProduction CreateProduction()
    {
        return new WallProduction();
    }
}