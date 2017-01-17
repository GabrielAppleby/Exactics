//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public TeamCharactersComponent teamCharacters { get { return (TeamCharactersComponent)GetComponent(GameComponentIds.TeamCharacters); } }
        public bool hasTeamCharacters { get { return HasComponent(GameComponentIds.TeamCharacters); } }

        public Entity AddTeamCharacters(string[] newCharacterIds) {
            var component = CreateComponent<TeamCharactersComponent>(GameComponentIds.TeamCharacters);
            component.characterIds = newCharacterIds;
            return AddComponent(GameComponentIds.TeamCharacters, component);
        }

        public Entity ReplaceTeamCharacters(string[] newCharacterIds) {
            var component = CreateComponent<TeamCharactersComponent>(GameComponentIds.TeamCharacters);
            component.characterIds = newCharacterIds;
            ReplaceComponent(GameComponentIds.TeamCharacters, component);
            return this;
        }

        public Entity RemoveTeamCharacters() {
            return RemoveComponent(GameComponentIds.TeamCharacters);
        }
    }
}

    public partial class GameMatcher {

        static IMatcher _matcherTeamCharacters;

        public static IMatcher TeamCharacters {
            get {
                if(_matcherTeamCharacters == null) {
                    var matcher = (Matcher)Matcher.AllOf(GameComponentIds.TeamCharacters);
                    matcher.componentNames = GameComponentIds.componentNames;
                    _matcherTeamCharacters = matcher;
                }

                return _matcherTeamCharacters;
            }
        }
    }
