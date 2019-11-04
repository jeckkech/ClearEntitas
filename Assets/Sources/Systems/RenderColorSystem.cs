using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderColorSystem : ReactiveSystem<GameEntity>
{

    readonly IGroup<GameEntity> _inputs;
    readonly GameContext _gameContext;

    public RenderColorSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities) {
           e.view.gameObject.GetComponent<SpriteRenderer>().color = e.color.color;         
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.isMovableSprite;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Color);
    }
}
