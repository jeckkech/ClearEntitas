using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderPositionSystem : ReactiveSystem<GameEntity>
{

    readonly IGroup<GameEntity> _inputs;
    readonly GameContext _gameContext;

    public RenderPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities) {             
           e.view.gameObject.transform.position = e.position.value;         
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView && entity.isMovableSprite;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }
}
