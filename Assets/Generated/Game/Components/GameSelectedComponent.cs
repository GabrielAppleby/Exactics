//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SelectedComponent selectedComponent = new SelectedComponent();

    public bool isSelected {
        get { return HasComponent(GameComponentsLookup.Selected); }
        set {
            if(value != isSelected) {
                if(value) {
                    AddComponent(GameComponentsLookup.Selected, selectedComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Selected);
                }
            }
        }
    }
}
