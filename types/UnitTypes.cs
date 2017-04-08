using UnityEngine;
using WorldMapStrategyKit;
using Zenject;

namespace CustomAssets.CustomScripting.types
{
    public class UnitType
    {

        private string _name;

        private UnitPrefabType _unitPrefabType;

        public static UnitType BASIC_SOLDIER = new UnitType()
        {
            _name = "Basic Soldier",
            _unitPrefabType = UnitPrefabType.BASIC_SOLDIER
        };
    }


}