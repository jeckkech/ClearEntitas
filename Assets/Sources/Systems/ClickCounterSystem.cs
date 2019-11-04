using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ClickCounterSystem : ReactiveSystem<InputEntity>
{
    readonly GameContext _gameContext;
    readonly InputContext _inputContext;
    readonly List<GameEntity> emittedColors;

    GameEntity _clickCounter;
    List<ClicksToColor> clicksToColorList;

    public ClickCounterSystem(Contexts contexts) : base(contexts.input)
    {
        _gameContext = contexts.game;
        _inputContext = contexts.input;

        emittedColors = new List<GameEntity>();

        _clickCounter = _gameContext.CreateEntity();
        _clickCounter.isClicks = true;
        _clickCounter.AddTotalClicksNumber(0);
    }   

    protected override void Execute(List<InputEntity> entities)
    {
        clicksToColorList = new List<ClicksToColor>(_gameContext.clicksToColorVariant.list);

        foreach (InputEntity e in entities) {            
            if (_clickCounter != null) {
                int numberOfClicks = _clickCounter.totalClicksNumber.totalClicks + 1;
                _clickCounter.ReplaceTotalClicksNumber(numberOfClicks);

                ClicksToColor clicksToColor = clicksToColorList.Find(c => numberOfClicks % c.clicksNumber == 0 );
                
                if (clicksToColor != null)
                {                    
                    _gameContext.CreateEntity().AddDebugMessage("Emitting change to color: " + clicksToColor.color);                   
                    CheckAndChangeColor(clicksToColor.color);
                    break;
                }
                else {
                    _gameContext.CreateEntity().AddDebugMessage("Emitting change to default color");                    
                    CheckAndChangeColor(Color.white);
                }
            }
            
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }

    private void CheckAndChangeColor(Color color) {
        if (_inputContext.hasCurrentTarget && _inputContext.currentTarget.entityRef != null)
        {
            _inputContext.currentTarget.entityRef.ReplaceColor(color);
        }
    }
}
