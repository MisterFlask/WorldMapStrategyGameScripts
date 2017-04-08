using System;
using UnityEngine;
using WorldMapStrategyKit;

namespace CustomAssets.CustomScripting.types
{
    public class UnitPrefabProvider : MonoBehaviour
    {
        public Transform BasicSoldierPrefab;


        public Transform GetUnitTransform(UnitPrefabType prefabType)
        {
            switch (prefabType)
            {
                    case UnitPrefabType.BASIC_SOLDIER :
                    return BasicSoldierPrefab;
            }
            Debug.LogError("Could not find prefab for " + prefabType);
            throw new Exception("Could not find prefab for " + prefabType);
        }
    }
}