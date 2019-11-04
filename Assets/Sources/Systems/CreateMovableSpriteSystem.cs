using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CreateMovableSpriteSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _gameContext;

    public CreateMovableSpriteSystem(Contexts contexts): base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        GameObject movableSpritePrefab = _gameContext.movableSpriteSettings.value.movableSpritePrefab;
        GameObject objectsRoot = _gameContext.gameObjectsRoot.value.gameObject;

        foreach(GameEntity entity in entities)
        {
            GameObject movableSprite = GameObject.Instantiate(movableSpritePrefab, objectsRoot.transform);
            movableSprite.transform.position = new Vector2(entity.position.value.x, entity.position.value.y);
            entity.AddView(movableSprite);
            movableSprite.Link(entity);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMovableSprite && entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MovableSprite));
    }
}
