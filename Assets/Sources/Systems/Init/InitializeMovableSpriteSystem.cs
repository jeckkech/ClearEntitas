using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InitializeMovableSpriteSystem : IInitializeSystem
{
    readonly GameContext _context;

    public InitializeMovableSpriteSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize()
    {
        GameEntity movableSprite = _context.CreateEntity();
        movableSprite.isMovableSprite = true;
        movableSprite.AddPosition(new Vector2(0, 0));
        movableSprite.AddColor(Color.white);            
    }
}
