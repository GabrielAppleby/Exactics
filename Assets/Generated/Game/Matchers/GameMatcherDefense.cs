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

    static IMatcher<GameEntity> _matcherDefense;

    public static IMatcher<GameEntity> Defense {
        get {
            if(_matcherDefense == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.Defense);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDefense = matcher;
            }

            return _matcherDefense;
        }
    }
}
