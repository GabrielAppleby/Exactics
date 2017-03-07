//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TeamLoadedListenerComponent teamLoadedListener { get { return (TeamLoadedListenerComponent)GetComponent(GameComponentsLookup.TeamLoadedListener); } }
    public bool hasTeamLoadedListener { get { return HasComponent(GameComponentsLookup.TeamLoadedListener); } }

    public void AddTeamLoadedListener(ITeamLoadedListener newListener) {
        var component = CreateComponent<TeamLoadedListenerComponent>(GameComponentsLookup.TeamLoadedListener);
        component.listener = newListener;
        AddComponent(GameComponentsLookup.TeamLoadedListener, component);
    }

    public void ReplaceTeamLoadedListener(ITeamLoadedListener newListener) {
        var component = CreateComponent<TeamLoadedListenerComponent>(GameComponentsLookup.TeamLoadedListener);
        component.listener = newListener;
        ReplaceComponent(GameComponentsLookup.TeamLoadedListener, component);
    }

    public void RemoveTeamLoadedListener() {
        RemoveComponent(GameComponentsLookup.TeamLoadedListener);
    }
}