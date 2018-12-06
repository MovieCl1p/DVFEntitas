//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.AddToRouteCompoent componentsAddToRouteCompoent { get { return (Components.AddToRouteCompoent)GetComponent(GameComponentsLookup.ComponentsAddToRouteCompoent); } }
    public bool hasComponentsAddToRouteCompoent { get { return HasComponent(GameComponentsLookup.ComponentsAddToRouteCompoent); } }

    public void AddComponentsAddToRouteCompoent(Components.RouteComponent newRoute) {
        var index = GameComponentsLookup.ComponentsAddToRouteCompoent;
        var component = (Components.AddToRouteCompoent)CreateComponent(index, typeof(Components.AddToRouteCompoent));
        component.Route = newRoute;
        AddComponent(index, component);
    }

    public void ReplaceComponentsAddToRouteCompoent(Components.RouteComponent newRoute) {
        var index = GameComponentsLookup.ComponentsAddToRouteCompoent;
        var component = (Components.AddToRouteCompoent)CreateComponent(index, typeof(Components.AddToRouteCompoent));
        component.Route = newRoute;
        ReplaceComponent(index, component);
    }

    public void RemoveComponentsAddToRouteCompoent() {
        RemoveComponent(GameComponentsLookup.ComponentsAddToRouteCompoent);
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

    static Entitas.IMatcher<GameEntity> _matcherComponentsAddToRouteCompoent;

    public static Entitas.IMatcher<GameEntity> ComponentsAddToRouteCompoent {
        get {
            if (_matcherComponentsAddToRouteCompoent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ComponentsAddToRouteCompoent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherComponentsAddToRouteCompoent = matcher;
            }

            return _matcherComponentsAddToRouteCompoent;
        }
    }
}
