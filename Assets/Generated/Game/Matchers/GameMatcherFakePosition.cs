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

    static IMatcher<GameEntity> _matcherFakePosition;

    public static IMatcher<GameEntity> FakePosition {
        get {
            if(_matcherFakePosition == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.FakePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFakePosition = matcher;
            }

            return _matcherFakePosition;
        }
    }
}
