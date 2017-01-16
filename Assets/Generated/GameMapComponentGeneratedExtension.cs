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

        public GameMapComponent gameMap { get { return (GameMapComponent)GetComponent(GameComponentIds.GameMap); } }
        public bool hasGameMap { get { return HasComponent(GameComponentIds.GameMap); } }

        public Entity AddGameMap(int newColumns, int newRows) {
            var component = CreateComponent<GameMapComponent>(GameComponentIds.GameMap);
            component.columns = newColumns;
            component.rows = newRows;
            return AddComponent(GameComponentIds.GameMap, component);
        }

        public Entity ReplaceGameMap(int newColumns, int newRows) {
            var component = CreateComponent<GameMapComponent>(GameComponentIds.GameMap);
            component.columns = newColumns;
            component.rows = newRows;
            ReplaceComponent(GameComponentIds.GameMap, component);
            return this;
        }

        public Entity RemoveGameMap() {
            return RemoveComponent(GameComponentIds.GameMap);
        }
    }

    public partial class Context {

        public Entity gameMapEntity { get { return GetGroup(GameMatcher.GameMap).GetSingleEntity(); } }
        public GameMapComponent gameMap { get { return gameMapEntity.gameMap; } }
        public bool hasGameMap { get { return gameMapEntity != null; } }

        public Entity SetGameMap(int newColumns, int newRows) {
            if(hasGameMap) {
                throw new EntitasException("Could not set gameMap!\n" + this + " already has an entity with GameMapComponent!",
                    "You should check if the context already has a gameMapEntity before setting it or use context.ReplaceGameMap().");
            }
            var entity = CreateEntity();
            entity.AddGameMap(newColumns, newRows);
            return entity;
        }

        public Entity ReplaceGameMap(int newColumns, int newRows) {
            var entity = gameMapEntity;
            if(entity == null) {
                entity = SetGameMap(newColumns, newRows);
            } else {
                entity.ReplaceGameMap(newColumns, newRows);
            }

            return entity;
        }

        public void RemoveGameMap() {
            DestroyEntity(gameMapEntity);
        }
    }
}

    public partial class GameMatcher {

        static IMatcher _matcherGameMap;

        public static IMatcher GameMap {
            get {
                if(_matcherGameMap == null) {
                    var matcher = (Matcher)Matcher.AllOf(GameComponentIds.GameMap);
                    matcher.componentNames = GameComponentIds.componentNames;
                    _matcherGameMap = matcher;
                }

                return _matcherGameMap;
            }
        }
    }
