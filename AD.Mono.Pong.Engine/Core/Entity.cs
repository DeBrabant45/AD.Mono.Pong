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
    private bool _isActive;
    private bool _isDestoryed;

    public Entity(string tag, bool isActive = true)
    {
        _tag = tag;
        _isActive = isActive;
        _components = new();
    }

    public bool IsActive => _isActive;
    public bool IsDestroyed => _isDestoryed;
    public string Tag => _tag;
    public event Action<IEntity> OnDestroyed;

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

    public void Unload()
    {
        foreach (var component in _components)
        {
            if (component is IUnload unloadableComponent)
            {
                unloadableComponent.Unload();
            }
        }
    }

    public void AddComponent<TComponent>(IComponent component) where TComponent : class, IComponent
    {
        if (!HasComponent<TComponent>())
            return;

        _components.Add(component);
    }

    public void RemoveComponent<TComponent>(IComponent component) where TComponent : class, IComponent
    {
        if (!HasComponent<TComponent>()) 
            return;

        _components.Remove(component);
    }

    public bool RemoveComponent<TComponent>() where TComponent : class, IComponent
    {
        var component = GetComponent<TComponent>();
        if (component == null)
            return false;

        RemoveComponent<TComponent>(component);
        return true;
    }

    public void RemoveAllComponents() => _components.Clear();

    public TComponent GetComponent<TComponent>() where TComponent : class, IComponent
    {
        if (!typeof(IComponent).IsAssignableFrom(typeof(TComponent)))
            throw new InvalidOperationException("TComponent must derive from IComponent!!");

        return _components.OfType<TComponent>().FirstOrDefault() ??
            throw new InvalidOperationException("Component does not exist on this entity!!"); ;
    }

    public List<TComponent> GetComponents<TComponent>() where TComponent : class, IComponent
    {
        return _components.OfType<TComponent>().ToList();
    }

    public bool HasComponent<TComponent>() where TComponent : class, IComponent
    {
        return _components.Any(component => component is TComponent);
    }

    public void Destroy()
    {
        _isActive = false;
        _isDestoryed = true;
        OnDestroyed.Invoke(this);
    }
}