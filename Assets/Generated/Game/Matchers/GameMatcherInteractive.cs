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

    static IMatcher<GameEntity> _matcherInteractive;

    public static IMatcher<GameEntity> Interactive {
        get {
            if(_matcherInteractive == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.Interactive);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractive = matcher;
            }

            return _matcherInteractive;
        }
    }
}