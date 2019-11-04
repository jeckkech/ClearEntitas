using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private Systems _systems;

    public MovableSpriteSettings movableSpriteSettings;
    public GameObject objectsRoot;
    public ClicksToColor[] clicksToColorVariant;

    void Start()
    {
        var contexts = Contexts.sharedInstance;

        _systems = CreateSystems(contexts);

        contexts.game.SetMovableSpriteSettings(movableSpriteSettings);
        contexts.game.SetGameObjectsRoot(objectsRoot);
        contexts.game.SetClicksToColorVariant(clicksToColorVariant);
        
        _systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts) {
        return new Feature("Systems")
            .Add(new InputSystems(contexts))
            .Add(new ClicksToColorSystems(contexts))
            .Add(new ViewSystems(contexts))
            .Add(new DebugSystems(contexts));
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
