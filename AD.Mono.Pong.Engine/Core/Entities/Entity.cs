using AD.Mono.Pong.Engine.Core.Components;
using AD.Mono.Pong.Engine.Core.LifeCycles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AD.Mono.Pong.Engine.Core.Entities;

public class Entity : IEntity
{
    private static int _idGenerator;
    private readonly string _tag;
    private readonly string _name;
    private readonly int _id;
    private readonly List<IComponent> _components;
    private bool _isActive;
    private bool _isDestoryed;
    private bool _isEnabled;

    public Entity(string tag, string name, bool isActive = true, bool isEnabled = true)
    {
        _id = _idGenerator++;
        _tag = tag;
        _name = name;
        _isActive = isActive;
        _isEnabled = isEnabled;
        _components = new();
    }

    // ToDo: Look into adding Component Repo
    // ToDo: Look into having two lists one for non-rendering components and another with rendering
    // ToDo: Or just call Render as a virutal 
    public int Id => _id;
    public string Name => _name;
    public bool IsActive => _isActive;
    public bool IsDestroyed => _isDestoryed;
    public bool IsEnabled => _isEnabled;
    public string Tag => _tag;

    public event Action<IEntity> OnDestroyed;

    public void Load()
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].Load();
        }
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].Update(deltaTime);
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
        if (HasComponent<TComponent>())
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
        return _components.OfType<TComponent>().FirstOrDefault() ??
            throw new InvalidOperationException($"{typeof(TComponent)} does not exist on this {ToString()}!");
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
    }

    public override string ToString()
    {
        return $"[Entity: name: {Name}, tag: {Tag}, enabled: {IsEnabled}]";
    }
}