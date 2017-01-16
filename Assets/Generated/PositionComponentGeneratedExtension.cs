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

        public PositionComponent position { get { return (PositionComponent)GetComponent(GameComponentIds.Position); } }
        public bool hasPosition { get { return HasComponent(GameComponentIds.Position); } }

        public Entity AddPosition(float newX, float newY) {
            var component = CreateComponent<PositionComponent>(GameComponentIds.Position);
            component.x = newX;
            component.y = newY;
            return AddComponent(GameComponentIds.Position, component);
        }

        public Entity ReplacePosition(float newX, float newY) {
            var component = CreateComponent<PositionComponent>(GameComponentIds.Position);
            component.x = newX;
            component.y = newY;
            ReplaceComponent(GameComponentIds.Position, component);
            return this;
        }

        public Entity RemovePosition() {
            return RemoveComponent(GameComponentIds.Position);
        }
    }
}

    public partial class GameMatcher {

        static IMatcher _matcherPosition;

        public static IMatcher Position {
            get {
                if(_matcherPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(GameComponentIds.Position);
                    matcher.componentNames = GameComponentIds.componentNames;
                    _matcherPosition = matcher;
                }

                return _matcherPosition;
            }
        }
    }
