using AD.Mono.Pong.Engine.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.Mono.Pong.Engine.Core;

public class Entity : IEntity
{
    private readonly string _tag;
    private readonly List<IComponent> _components;
    private bool _isActive = true;

    public Entity(string tag)
    {
        _tag = tag;
        _components = new();
    }

    public bool IsActive => _isActive;
    public string Tag => _tag;

    public void Load()
    {
        foreach (var component in _components)
        {
            component.Load();
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var component in _components)
        {
            component.Update(deltaTime);
        }
    }

    public void Render(SpriteBatch spriteBatch)
    {
        foreach (var component in _components)
        {
            if (component is IRender renderableComponent)
            {
                renderableComponent.Render(spriteBatch);
            }
        }
    }

    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent
    {
        _components.Add(component);
    }

    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent
    {
        _components.Remove(component);
    }

    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent
    {
        if (!typeof(IComponent).IsAssignableFrom(typeof(TComponent)))
            throw new InvalidOperationException("TComponent must derive from IComponent!!");

        return _components.OfType<TComponent>().FirstOrDefault() ??
            throw new InvalidOperationException("Component does not exist on this entity!!"); ;
    }

    public void Destroy()
    {
        _isActive = false;
    }

    public void Unload()
    {
        foreach(var component in _components)
        {
            if(component is IUnload unloadableComponent)
            {
                unloadableComponent.Unload();
            }
        }
    }
}