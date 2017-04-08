using System;
using CustomAssets.CustomScripting.types;
using UnityEngine;

namespace CustomAssets.CustomScripting.units
{
    public class WorldMapGameUnit
    {
        public UnitType UnitType { get; set; }

        private Guid _guid = System.Guid.NewGuid();

        public string _name = "unnamed";

        public string _playerName = "human";

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}