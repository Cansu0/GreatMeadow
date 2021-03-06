using System.Collections.Generic;
using DataStructures.Variables;
using Features.Maze_Namespace;
using Features.Maze_Namespace.Tiles;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileBehaviour : GameObjectActiveSwitchBehaviour
{
    [SerializeField] private TileList_SO tileList;
    
    public Vector2Int position { get; private set; }
    public List<Vector2IntVariable> directions { get; private set; }
    
    private InteractableBehaviour interactable;
    
    public void Initialize(Tile tile)
    {
        position = tile.position;
        tileList.RegisterTile(this);
        directions = tile.directions;
    }

    public void RegisterInteractable(InteractableBehaviour interactable)
    {
        this.interactable = interactable;
    }
    
    public bool ContainsInteractable() => interactable != null;

    public override void PrepareRenderer()
    {
        base.PrepareRenderer();

        if (interactable != null)
        {
            interactable.PrepareRenderer();
        }
    }

    public override void Enable()
    {
        base.Enable();
        
        if (interactable != null)
        {
            interactable.Enable();
        }
    }

    public override void Disable()
    {
        base.Disable();
        
        if (interactable != null)
        {
            interactable.Disable();
        }
    }
}
