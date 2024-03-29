//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;
            
public partial class Contexts : IContexts {

    public static Contexts sharedInstance {
        get {
            if(_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public static void CreateContextObserver(IContext context) {
#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        if(UnityEngine.Application.isPlaying) {
            var observer = new Entitas.Unity.VisualDebugging.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
#endif
    }

    public AppContext app { get; set; }
    public GameContext game { get; set; }
    public GamePersStateContext gamePersState { get; set; }
    public GameUIContext gameUI { get; set; }
    public InputContext input { get; set; }

    public IContext[] allContexts { get { return new IContext [] { app, game, gamePersState, gameUI, input }; } }

    public void SetAllContexts() {
        app = new AppContext();
        game = new GameContext();
        gamePersState = new GamePersStateContext();
        gameUI = new GameUIContext();
        input = new InputContext();

        CreateContextObserver(app);
        CreateContextObserver(game);
        CreateContextObserver(gamePersState);
        CreateContextObserver(gameUI);
        CreateContextObserver(input);
    }
}
