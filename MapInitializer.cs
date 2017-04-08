using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CustomAssets.CustomScripting.common.inject;
using CustomAssets.CustomScripting.common.MapUtils;
using CustomAssets.CustomScripting.types;
using UnityEngine;
using WorldMapStrategyKit;
using Zenject;

namespace CustomAssets.CustomScripting
{
    public class MapInitializer : MonoBehaviour
    {
        private MapUtils mapUtils;

        private CanvasState canvasState;

        [Inject]
        public void Construct(MapUtils mapUtils, CanvasState canvasState)
        {
            Debug.Log("Injecting maputils into MapInitializer");
            this.mapUtils = mapUtils;
            this.canvasState = canvasState;
        }


        [Header(("Dependencies"))]
        public WMSK map;
        // Use this for initialization
        void Start () {
            map.OnProvinceEnter += (int provinceIndex, int regionIndex) => Debug.Log ("Entered province " + map.provinces [provinceIndex].name + " , owned by " + map.GetCountry(map.provinces [provinceIndex].countryIndex).name);
            map.OnProvinceExit += (int provinceIndex, int regionIndex) => Debug.Log ("Exited province " + map.provinces [provinceIndex].name);
            map.OnProvinceClick += (int provinceIndex, int regionIndex, int buttonIndex) =>
            {
                Debug.Log("Clicked province " + map.provinces[provinceIndex].name);
                canvasState.ProvinceSelected = new ProvinceIdentifier(){Province = map.provinces[provinceIndex].name, Nation = map.GetCountry(map.provinces[provinceIndex].countryIndex).name};
            };
        }

        // Update is called once per frame
        void Update () {
            if (Input.GetKeyDown(KeyCode.U)){
                populate ();
            }
        }

        void populate(){

            foreach (GameCountry country in GameCountry.GetStartingGameCountries())
            {
                if (country == null)
                {
                    Debug.Log("Country shouldn't be null here.");
                    continue;
                }
                bool countryHasBeenSpawned = mapUtils.DoesCountryExist(country.Name);

                foreach (ProvinceIdentifier identifier in country.GetProvinceIdentifiers())
                {
                    if (!countryHasBeenSpawned)
                    {
                        mapUtils.SpawnNewCountry(identifier, country);
                        countryHasBeenSpawned = true;
                    }
                    else
                    {
                        mapUtils.TransferControlOfProvince(identifier, country);
                    }
                }
                mapUtils.ToggleNationFlagsOnMap(true);
            }

        }

    }
}
