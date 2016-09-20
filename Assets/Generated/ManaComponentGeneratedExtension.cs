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
        public ManaComponent mana { get { return (ManaComponent)GetComponent(CoreComponentIds.Mana); } }

        public bool hasMana { get { return HasComponent(CoreComponentIds.Mana); } }

        public Entity AddMana(int newMana) {
            var component = CreateComponent<ManaComponent>(CoreComponentIds.Mana);
            component.mana = newMana;
            return AddComponent(CoreComponentIds.Mana, component);
        }

        public Entity ReplaceMana(int newMana) {
            var component = CreateComponent<ManaComponent>(CoreComponentIds.Mana);
            component.mana = newMana;
            ReplaceComponent(CoreComponentIds.Mana, component);
            return this;
        }

        public Entity RemoveMana() {
            return RemoveComponent(CoreComponentIds.Mana);
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherMana;

        public static IMatcher Mana {
            get {
                if (_matcherMana == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Mana);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherMana = matcher;
                }

                return _matcherMana;
            }
        }
    }
