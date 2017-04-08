using CustomAssets.CustomScripting.types;
using CustomAssets.CustomScripting.units;
using UnityEngine;

namespace CustomAssets.CustomScripting.ui
{
    [RequireComponent(typeof(WorldMapGameUnit))]
    public class GameUnitBehavior : MonoBehaviour
    {
        public WorldMapGameUnit UnitAttributes { get; set; }

        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Unit clicked!  Unit is owned by player " + UnitAttributes.PlayerName);
            }
        }
    }
}