using CustomAssets.CustomScripting.common.MapUtils;
using CustomAssets.CustomScripting.gamestate;
using CustomAssets.CustomScripting.types;
using WorldMapStrategyKit;
using Zenject;

namespace CustomAssets.CustomScripting.common.inject
{
    public class StrategyMapInstaller : MonoInstaller
    {
        public FlagProvider flagProvider;

        public MapUtils.MapUtils mapUtils;

        public UnitPrefabProvider unitProvider;

        public CanvasState canvasState;

        public WMSK map;

        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Hello World!");
            Container.Bind<FlagProvider>().FromInstance(flagProvider);
            Container.Bind<UnitPrefabProvider>().FromInstance(unitProvider);
            Container.Bind<WMSK>().FromInstance(map);
            Container.Bind<MapUtils.MapUtils>().FromInstance(mapUtils);
            Container.Bind<CanvasState>().FromInstance(canvasState);
            Container.Bind<GameState>().FromInstance(new GameState());
        }
    }
}