//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.ConveyerTransitionComponent componentsConveyerTransition { get { return (Components.ConveyerTransitionComponent)GetComponent(GameComponentsLookup.ComponentsConveyerTransition); } }
    public bool hasComponentsConveyerTransition { get { return HasComponent(GameComponentsLookup.ComponentsConveyerTransition); } }

    public void AddComponentsConveyerTransition(string newTo, float newDistance, UnityEngine.Vector3 newEndPoint) {
        var index = GameComponentsLookup.ComponentsConveyerTransition;
        var component = (Components.ConveyerTransitionComponent)CreateComponent(index, typeof(Components.ConveyerTransitionComponent));
        component.To = newTo;
        component.Distance = newDistance;
        component.EndPoint = newEndPoint;
        AddComponent(index, component);
    }

    public void ReplaceComponentsConveyerTransition(string newTo, float newDistance, UnityEngine.Vector3 newEndPoint) {
        var index = GameComponentsLookup.ComponentsConveyerTransition;
        var component = (Components.ConveyerTransitionComponent)CreateComponent(index, typeof(Components.ConveyerTransitionComponent));
        component.To = newTo;
        component.Distance = newDistance;
        component.EndPoint = newEndPoint;
        ReplaceComponent(index, component);
    }

    public void RemoveComponentsConveyerTransition() {
        RemoveComponent(GameComponentsLookup.ComponentsConveyerTransition);
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

    static Entitas.IMatcher<GameEntity> _matcherComponentsConveyerTransition;

    public static Entitas.IMatcher<GameEntity> ComponentsConveyerTransition {
        get {
            if (_matcherComponentsConveyerTransition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ComponentsConveyerTransition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherComponentsConveyerTransition = matcher;
            }

            return _matcherComponentsConveyerTransition;
        }
    }
}
