//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SaveDirectoryComponent saveDirectoryComponent = new SaveDirectoryComponent();

    public bool isSaveDirectory {
        get { return HasComponent(GameComponentsLookup.SaveDirectory); }
        set {
            if(value != isSaveDirectory) {
                if(value) {
                    AddComponent(GameComponentsLookup.SaveDirectory, saveDirectoryComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.SaveDirectory);
                }
            }
        }
    }
}
