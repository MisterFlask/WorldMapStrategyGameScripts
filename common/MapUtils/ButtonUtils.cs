using CustomAssets.CustomScripting.types;
using UnityEngine;
using Zenject;

namespace CustomAssets.CustomScripting.common.MapUtils
{
    public class ButtonUtils : MonoBehaviour
    {
        [Inject]
        private MapUtils _mapUtils;

        [Inject] private CanvasState _canvasState;


        public void createUnitAtSelectedLocation()
        {
            Debug.Log("Creating unit at " + _canvasState.ProvinceSelected.Province);
            var province = _canvasState.ProvinceSelected;
            _mapUtils.CreateUnit(UnitType.BASIC_SOLDIER, province);
        }

        public void CreateEnemyUnitAtSelectedLocation()
        {
            Debug.Log("Creating unit at " + _canvasState.ProvinceSelected.Province);
            var province = _canvasState.ProvinceSelected;
            _mapUtils.CreateUnit(UnitType.BASIC_SOLDIER, province);
        }

    }
}