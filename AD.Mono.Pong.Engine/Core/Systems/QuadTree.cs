using AD.Mono.Pong.Engine.Core.Components.Physics;
using AD.Mono.Pong.Engine.Core.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AD.Mono.Pong.Engine.Core.Systems;

// Quadtree class for managing collision detection
public class QuadTree
{
    private QuadTreeNode _root;

    // Constructor to initialize the quadtree with bounds
    public QuadTree(Rectangle bounds)
    {
        _root = new QuadTreeNode(bounds);
    }

    // Add entity to quadtree
    public void Insert(IEntity entity)
    {
        // Implement logic to insert entity into appropriate quadtree nodes based on its position
        // This involves subdividing the tree and adding the entity to corresponding nodes
    }

    // Check collisions within a node and its children
    private void CheckCollisions(QuadTreeNode node)
    {
        List<IEntity> entities = node.Entities;

        for (int i = 0; i < entities.Count; i++)
        {
            for (int j = i + 1; j < entities.Count; j++)
            {
                IEntity entityA = entities[i];
                IEntity entityB = entities[j];
                var aRect = entityA.GetComponent<Rigidbody>().Body;
                var bRect = entityB.GetComponent<Rigidbody>().Body;
                // Perform collision check between entityA and entityB
                // This could involve using their respective collision bounds
                // If a collision is detected, trigger OnCollision events or perform necessary actions
                // Example: if (entityA.Bounds.Intersects(entityB.Bounds)) { ... }
                if (aRect.Intersects(bRect))
                {
                    // Collision detected
                    //entityA.OnCollisionTrigger(entityB);
                    //entityB.OnCollisionTrigger(entityA);
                }
            }
        }

        // Recursively check collisions in child nodes
        foreach (var child in node.Children)
        {
            if (child != null)
                CheckCollisions(child);
        }
    }

    // Public method to initiate collision checks
    public void DetectCollisions()
    {
        CheckCollisions(_root);
    }
}

// Define a Quadtree node
public class QuadTreeNode
{
    public Rectangle Bounds { get; }
    public List<IEntity> Entities { get; }
    public QuadTreeNode[] Children { get; }

    // Constructor to create a node with bounds
    public QuadTreeNode(Rectangle bounds)
    {
        Bounds = bounds;
        Entities = new List<IEntity>();
        Children = new QuadTreeNode[4]; // Four children for quadrants
    }

    // Other methods for subdividing the tree, adding entities, etc. can go here...
}