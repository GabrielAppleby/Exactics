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

    static IMatcher<GameEntity> _matcherTeamLoaded;

    public static IMatcher<GameEntity> TeamLoaded {
        get {
            if(_matcherTeamLoaded == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.TeamLoaded);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTeamLoaded = matcher;
            }

            return _matcherTeamLoaded;
        }
    }
}
