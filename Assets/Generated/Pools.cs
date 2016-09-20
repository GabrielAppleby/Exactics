//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.PoolsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Pools {

        public static Pool CreateCorePool() {
            return CreatePool("Core", CoreComponentIds.TotalComponents, CoreComponentIds.componentNames, CoreComponentIds.componentTypes);
        }

        public static Pool CreateInputPool() {
            return CreatePool("Input", InputComponentIds.TotalComponents, InputComponentIds.componentNames, InputComponentIds.componentTypes);
        }

        public static Pool CreateUIPool() {
            return CreatePool("UI", UIComponentIds.TotalComponents, UIComponentIds.componentNames, UIComponentIds.componentTypes);
        }

        public Pool[] allPools { get { return new [] { core, input, uI }; } }

        public Pool core;
        public Pool input;
        public Pool uI;

        public void SetAllPools() {
            core = CreateCorePool();
            input = CreateInputPool();
            uI = CreateUIPool();
        }
    }
}
