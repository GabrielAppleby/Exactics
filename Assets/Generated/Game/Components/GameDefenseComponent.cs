//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DefenseComponent defense { get { return (DefenseComponent)GetComponent(GameComponentsLookup.Defense); } }
    public bool hasDefense { get { return HasComponent(GameComponentsLookup.Defense); } }

    public void AddDefense(int newDefense, int newHealth, int newCurrentHealth, int newFortitude, int newResistance, int newEvasion) {
        var component = CreateComponent<DefenseComponent>(GameComponentsLookup.Defense);
        component.defense = newDefense;
        component.health = newHealth;
        component.currentHealth = newCurrentHealth;
        component.fortitude = newFortitude;
        component.resistance = newResistance;
        component.evasion = newEvasion;
        AddComponent(GameComponentsLookup.Defense, component);
    }

    public void ReplaceDefense(int newDefense, int newHealth, int newCurrentHealth, int newFortitude, int newResistance, int newEvasion) {
        var component = CreateComponent<DefenseComponent>(GameComponentsLookup.Defense);
        component.defense = newDefense;
        component.health = newHealth;
        component.currentHealth = newCurrentHealth;
        component.fortitude = newFortitude;
        component.resistance = newResistance;
        component.evasion = newEvasion;
        ReplaceComponent(GameComponentsLookup.Defense, component);
    }

    public void RemoveDefense() {
        RemoveComponent(GameComponentsLookup.Defense);
    }
}
