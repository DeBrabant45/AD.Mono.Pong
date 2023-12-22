using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core;

public class Registry : ILoad, IUpdate, IRender
{
    private readonly IList<IEntity> _entities;

	public Registry(IList<IEntity> entities)
	{
		_entities = entities;
	}

	public IList<IEntity> Entities => _entities;

    public void AddEntity(IEntity entity) => _entities.Add(entity);

	public void RemoveEntity(IEntity entity) => _entities.Remove(entity);

    public void Load()
	{
		foreach (var entity in _entities)
		{
			entity.Load();
		}
	}

	public void Update(float deltaTime)
	{
		foreach (var entity in _entities)
		{
			entity.Update(deltaTime);
		}
	}

    public void Render(SpriteBatch spriteBatch)
    {
        foreach (var entity in _entities)
        {
            entity.Render(spriteBatch);
        }
    }
}
