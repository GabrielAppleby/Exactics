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

    static IMatcher<GameEntity> _matcherGameEnd;

    public static IMatcher<GameEntity> GameEnd {
        get {
            if(_matcherGameEnd == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.GameEnd);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameEnd = matcher;
            }

            return _matcherGameEnd;
        }
    }
}
