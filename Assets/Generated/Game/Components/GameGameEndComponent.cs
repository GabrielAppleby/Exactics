//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameEndComponent gameEndComponent = new GameEndComponent();

    public bool isGameEnd {
        get { return HasComponent(GameComponentsLookup.GameEnd); }
        set {
            if(value != isGameEnd) {
                if(value) {
                    AddComponent(GameComponentsLookup.GameEnd, gameEndComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.GameEnd);
                }
            }
        }
    }
}
