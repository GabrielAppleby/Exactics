//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public OffenseComponent offense { get { return (OffenseComponent)GetComponent(GameComponentsLookup.Offense); } }
    public bool hasOffense { get { return HasComponent(GameComponentsLookup.Offense); } }

    public void AddOffense(int newExpertise, int newAccuracy, int newDamage, int newSpellpower) {
        var component = CreateComponent<OffenseComponent>(GameComponentsLookup.Offense);
        component.expertise = newExpertise;
        component.accuracy = newAccuracy;
        component.damage = newDamage;
        component.spellpower = newSpellpower;
        AddComponent(GameComponentsLookup.Offense, component);
    }

    public void ReplaceOffense(int newExpertise, int newAccuracy, int newDamage, int newSpellpower) {
        var component = CreateComponent<OffenseComponent>(GameComponentsLookup.Offense);
        component.expertise = newExpertise;
        component.accuracy = newAccuracy;
        component.damage = newDamage;
        component.spellpower = newSpellpower;
        ReplaceComponent(GameComponentsLookup.Offense, component);
    }

    public void RemoveOffense() {
        RemoveComponent(GameComponentsLookup.Offense);
    }
}
