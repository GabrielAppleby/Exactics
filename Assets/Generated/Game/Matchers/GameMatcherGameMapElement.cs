//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class GameMatcher {

    static IMatcher<GameEntity> _matcherGameMapElement;

    public static IMatcher<GameEntity> GameMapElement {
        get {
            if(_matcherGameMapElement == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.GameMapElement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameMapElement = matcher;
            }

            return _matcherGameMapElement;
        }
    }
}
