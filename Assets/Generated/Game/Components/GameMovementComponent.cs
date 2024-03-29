//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MovementComponent movement { get { return (MovementComponent)GetComponent(GameComponentsLookup.Movement); } }
    public bool hasMovement { get { return HasComponent(GameComponentsLookup.Movement); } }

    public void AddMovement(int newMovement, int newCurrentMovement) {
        var component = CreateComponent<MovementComponent>(GameComponentsLookup.Movement);
        component.movement = newMovement;
        component.currentMovement = newCurrentMovement;
        AddComponent(GameComponentsLookup.Movement, component);
    }

    public void ReplaceMovement(int newMovement, int newCurrentMovement) {
        var component = CreateComponent<MovementComponent>(GameComponentsLookup.Movement);
        component.movement = newMovement;
        component.currentMovement = newCurrentMovement;
        ReplaceComponent(GameComponentsLookup.Movement, component);
    }

    public void RemoveMovement() {
        RemoveComponent(GameComponentsLookup.Movement);
    }
}
