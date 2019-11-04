using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CreateClickCounterSystem : IInitializeSystem
{
    readonly GameContext _gameContext;
    public CreateClickCounterSystem(Contexts contexts) 
    {
        _gameContext = contexts.game;
    }

    public void Initialize()
    {
        GameEntity totalClicks = _gameContext.CreateEntity();
        totalClicks.isClicks = true;
        totalClicks.AddTotalClicksNumber(0);
    }
}
