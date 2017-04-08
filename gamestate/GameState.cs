using System;
using System.Collections.Generic;
using System.Linq;
using CustomAssets.CustomScripting.units;
using Zenject;

namespace CustomAssets.CustomScripting.gamestate
{
    public class GameState
    {
        [Inject]
        public GameState()
        {
            this._gameUnits = new List<WorldMapGameUnit>();
        }


        private List<WorldMapGameUnit> _gameUnits;

        public WorldMapGameUnit CreateUnit(WorldMapGameUnit unit)
        {
            if (_gameUnits.Any(item => item.Guid.Equals(unit.Guid)))
            {
                throw new ArgumentException("Unit already exists in field");
            }
            _gameUnits.Add(unit);
            return unit;
        }

        public WorldMapGameUnit GetUnit(Guid uuid)
        {
            return _gameUnits.Find(item => item.Guid.Equals(uuid));
        }
    }
}