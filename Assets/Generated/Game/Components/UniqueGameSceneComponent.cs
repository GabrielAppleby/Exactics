//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public partial class GameContext {

    public GameEntity sceneEntity { get { return GetGroup(GameMatcher.Scene).GetSingleEntity(); } }
    public SceneComponent scene { get { return sceneEntity.scene; } }
    public bool hasScene { get { return sceneEntity != null; } }

    public GameEntity SetScene(string newSceneName) {
        if(hasScene) {
            throw new EntitasException("Could not set scene!\n" + this + " already has an entity with SceneComponent!",
                "You should check if the context already has a sceneEntity before setting it or use context.ReplaceScene().");
        }
        var entity = CreateEntity();
        entity.AddScene(newSceneName);
        return entity;
    }

    public void ReplaceScene(string newSceneName) {
        var entity = sceneEntity;
        if(entity == null) {
            entity = SetScene(newSceneName);
        } else {
            entity.ReplaceScene(newSceneName);
        }
    }

    public void RemoveScene() {
        DestroyEntity(sceneEntity);
    }
}
