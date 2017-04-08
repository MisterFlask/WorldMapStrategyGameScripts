using CustomAssets.CustomScripting.types;
using UnityEngine;
using Zenject;

namespace CustomAssets.CustomScripting.common.MapUtils
{
    public class CanvasState : MonoBehaviour
    {

        private ProvinceIdentifier _provinceSelected = null;

        public ProvinceIdentifier ProvinceSelected
        {
            get { return _provinceSelected; }
            set { _provinceSelected = value; }
        }


        private MapUtils _mapUtils;
        [Inject]
        public void Costruct(MapUtils mapUtils)
        {
            this._mapUtils = mapUtils;
        }
        private bool _areStatesShowingFlags = false;

        public void ToggleNationFlagsOnMap()
        {
            Debug.Log("Toggling nation flags on map");
            _mapUtils.ToggleNationFlagsOnMap(!_areStatesShowingFlags);
            this._areStatesShowingFlags = !_areStatesShowingFlags;
        }

    }
}