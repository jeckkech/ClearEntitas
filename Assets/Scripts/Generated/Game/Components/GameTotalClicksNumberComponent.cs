//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TotalClicksNumberComponent totalClicksNumber { get { return (TotalClicksNumberComponent)GetComponent(GameComponentsLookup.TotalClicksNumber); } }
    public bool hasTotalClicksNumber { get { return HasComponent(GameComponentsLookup.TotalClicksNumber); } }

    public void AddTotalClicksNumber(int newTotalClicks) {
        var index = GameComponentsLookup.TotalClicksNumber;
        var component = (TotalClicksNumberComponent)CreateComponent(index, typeof(TotalClicksNumberComponent));
        component.totalClicks = newTotalClicks;
        AddComponent(index, component);
    }

    public void ReplaceTotalClicksNumber(int newTotalClicks) {
        var index = GameComponentsLookup.TotalClicksNumber;
        var component = (TotalClicksNumberComponent)CreateComponent(index, typeof(TotalClicksNumberComponent));
        component.totalClicks = newTotalClicks;
        ReplaceComponent(index, component);
    }

    public void RemoveTotalClicksNumber() {
        RemoveComponent(GameComponentsLookup.TotalClicksNumber);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTotalClicksNumber;

    public static Entitas.IMatcher<GameEntity> TotalClicksNumber {
        get {
            if (_matcherTotalClicksNumber == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TotalClicksNumber);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTotalClicksNumber = matcher;
            }

            return _matcherTotalClicksNumber;
        }
    }
}
