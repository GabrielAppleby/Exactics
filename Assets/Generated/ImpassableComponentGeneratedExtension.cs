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

        static readonly ImpassableComponent impassableComponent = new ImpassableComponent();

        public bool isImpassable {
            get { return HasComponent(CoreComponentIds.Impassable); }
            set {
                if(value != isImpassable) {
                    if(value) {
                        AddComponent(CoreComponentIds.Impassable, impassableComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.Impassable);
                    }
                }
            }
        }

        public Entity IsImpassable(bool value) {
            isImpassable = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherImpassable;

        public static IMatcher Impassable {
            get {
                if(_matcherImpassable == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Impassable);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherImpassable = matcher;
                }

                return _matcherImpassable;
            }
        }
    }
