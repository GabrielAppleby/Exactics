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
        public StaminaComponent stamina { get { return (StaminaComponent)GetComponent(CoreComponentIds.Stamina); } }

        public bool hasStamina { get { return HasComponent(CoreComponentIds.Stamina); } }

        public Entity AddStamina(int newStamina) {
            var component = CreateComponent<StaminaComponent>(CoreComponentIds.Stamina);
            component.stamina = newStamina;
            return AddComponent(CoreComponentIds.Stamina, component);
        }

        public Entity ReplaceStamina(int newStamina) {
            var component = CreateComponent<StaminaComponent>(CoreComponentIds.Stamina);
            component.stamina = newStamina;
            ReplaceComponent(CoreComponentIds.Stamina, component);
            return this;
        }

        public Entity RemoveStamina() {
            return RemoveComponent(CoreComponentIds.Stamina);
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherStamina;

        public static IMatcher Stamina {
            get {
                if (_matcherStamina == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Stamina);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherStamina = matcher;
                }

                return _matcherStamina;
            }
        }
    }
