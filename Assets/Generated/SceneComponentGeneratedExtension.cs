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

        public SceneComponent scene { get { return (SceneComponent)GetComponent(MenuComponentIds.Scene); } }
        public bool hasScene { get { return HasComponent(MenuComponentIds.Scene); } }

        public Entity AddScene(string newSceneName) {
            var component = CreateComponent<SceneComponent>(MenuComponentIds.Scene);
            component.sceneName = newSceneName;
            return AddComponent(MenuComponentIds.Scene, component);
        }

        public Entity ReplaceScene(string newSceneName) {
            var component = CreateComponent<SceneComponent>(MenuComponentIds.Scene);
            component.sceneName = newSceneName;
            ReplaceComponent(MenuComponentIds.Scene, component);
            return this;
        }

        public Entity RemoveScene() {
            return RemoveComponent(MenuComponentIds.Scene);
        }
    }

    public partial class Pool {

        public Entity sceneEntity { get { return GetGroup(MenuMatcher.Scene).GetSingleEntity(); } }
        public SceneComponent scene { get { return sceneEntity.scene; } }
        public bool hasScene { get { return sceneEntity != null; } }

        public Entity SetScene(string newSceneName) {
            if(hasScene) {
                throw new EntitasException("Could not set scene!\n" + this + " already has an entity with SceneComponent!",
                    "You should check if the pool already has a sceneEntity before setting it or use pool.ReplaceScene().");
            }
            var entity = CreateEntity();
            entity.AddScene(newSceneName);
            return entity;
        }

        public Entity ReplaceScene(string newSceneName) {
            var entity = sceneEntity;
            if(entity == null) {
                entity = SetScene(newSceneName);
            } else {
                entity.ReplaceScene(newSceneName);
            }

            return entity;
        }

        public void RemoveScene() {
            DestroyEntity(sceneEntity);
        }
    }
}

    public partial class MenuMatcher {

        static IMatcher _matcherScene;

        public static IMatcher Scene {
            get {
                if(_matcherScene == null) {
                    var matcher = (Matcher)Matcher.AllOf(MenuComponentIds.Scene);
                    matcher.componentNames = MenuComponentIds.componentNames;
                    _matcherScene = matcher;
                }

                return _matcherScene;
            }
        }
    }
