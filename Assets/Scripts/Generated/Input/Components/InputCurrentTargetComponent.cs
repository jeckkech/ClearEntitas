//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity currentTargetEntity { get { return GetGroup(InputMatcher.CurrentTarget).GetSingleEntity(); } }
    public CurrentTarget currentTarget { get { return currentTargetEntity.currentTarget; } }
    public bool hasCurrentTarget { get { return currentTargetEntity != null; } }

    public InputEntity SetCurrentTarget(GameEntity newEntityRef) {
        if (hasCurrentTarget) {
            throw new Entitas.EntitasException("Could not set CurrentTarget!\n" + this + " already has an entity with CurrentTarget!",
                "You should check if the context already has a currentTargetEntity before setting it or use context.ReplaceCurrentTarget().");
        }
        var entity = CreateEntity();
        entity.AddCurrentTarget(newEntityRef);
        return entity;
    }

    public void ReplaceCurrentTarget(GameEntity newEntityRef) {
        var entity = currentTargetEntity;
        if (entity == null) {
            entity = SetCurrentTarget(newEntityRef);
        } else {
            entity.ReplaceCurrentTarget(newEntityRef);
        }
    }

    public void RemoveCurrentTarget() {
        currentTargetEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public CurrentTarget currentTarget { get { return (CurrentTarget)GetComponent(InputComponentsLookup.CurrentTarget); } }
    public bool hasCurrentTarget { get { return HasComponent(InputComponentsLookup.CurrentTarget); } }

    public void AddCurrentTarget(GameEntity newEntityRef) {
        var index = InputComponentsLookup.CurrentTarget;
        var component = (CurrentTarget)CreateComponent(index, typeof(CurrentTarget));
        component.entityRef = newEntityRef;
        AddComponent(index, component);
    }

    public void ReplaceCurrentTarget(GameEntity newEntityRef) {
        var index = InputComponentsLookup.CurrentTarget;
        var component = (CurrentTarget)CreateComponent(index, typeof(CurrentTarget));
        component.entityRef = newEntityRef;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentTarget() {
        RemoveComponent(InputComponentsLookup.CurrentTarget);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherCurrentTarget;

    public static Entitas.IMatcher<InputEntity> CurrentTarget {
        get {
            if (_matcherCurrentTarget == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.CurrentTarget);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCurrentTarget = matcher;
            }

            return _matcherCurrentTarget;
        }
    }
}
