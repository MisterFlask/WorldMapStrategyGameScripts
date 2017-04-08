using System;
using CustomAssets.CustomScripting.gamestate;
using CustomAssets.CustomScripting.types;
using CustomAssets.CustomScripting.ui;
using CustomAssets.CustomScripting.units;
using UnityEngine;
using WorldMapStrategyKit;
using Zenject;
using Zenject.Asteroids;

namespace CustomAssets.CustomScripting.common.MapUtils
{
    public class MapUtils : MonoBehaviour
    {

        private WMSK _map;

        private UnitPrefabProvider _prefabProvider;

        private FlagProvider _flagProvider;

        public GameState _gameState;

        [Inject]
        public void Construct(WMSK map, FlagProvider flagProvider, UnitPrefabProvider prefabProvider,
            GameState gameState)
        {
            this._gameState = gameState;
            this._prefabProvider = prefabProvider;
            this._map = map;
            this._flagProvider = flagProvider;
        }

        public void CreateUnit(UnitType unit, ProvinceIdentifier province)
        {

            Province mapProvince = _map.GetProvince(province.Province, province.Nation);

            // Get city location
            Vector2 cityPosition = mapProvince.center;

            GameObject soldierGO = Instantiate (_prefabProvider.GetUnitTransform(UnitPrefabType.BASIC_SOLDIER)).gameObject;
            soldierGO.transform.Rotate(Vector3.up, 180);
            GameObjectAnimator soldier = soldierGO.WMSK_MoveTo (cityPosition);
            soldier.autoRotation = false;
            soldier.terrainCapability = TERRAIN_CAPABILITY.OnlyGround;

            var guid = Guid.NewGuid();

            // Set tank ownership
            soldier.attrib["player"] = 1;
            soldier.attrib["uuid"] = guid.ToString();
            var createdUnit = _gameState.CreateUnit(new WorldMapGameUnit()
            {
                UnitType = unit,
                Guid = guid,
                Name = "SuccessfullyCreated!"
            });

            soldierGO.GetComponent<GameUnitBehavior>().UnitAttributes = createdUnit;

        }
        public bool DoesCountryExist(string country)
        {
            return _map.GetCountry(country) != null;
        }


        public void ToggleNationFlagsOnMap(bool useFlags)
        {
            foreach (GameCountry country in GameCountry.GetStartingGameCountries())
            {
                if (!DoesCountryExist(country.Name))
                {
                    continue;
                }
                var newCountryIndex = _map.GetCountryIndex(_map.GetCountry(country.Name));
                _map.ToggleCountryMainRegionSurface(newCountryIndex, useFlags, _flagProvider.getFlag(country.Flag));
            }
        }

        public void TransferControlOfProvince(ProvinceIdentifier id, GameCountry newCountry)
        {
            Debug.Assert(id != null);
            Debug.Assert(newCountry != null);
            Debug.Log("Transferring control of province  : " + id.Province);
            var province = _map.GetProvince (id.Province, id.Nation);
            var newCountryIndex = _map.GetCountryIndex(_map.GetCountry(newCountry.Name));
            _map.CountryTransferProvinceRegion(newCountryIndex, province.mainRegion);
            //_map.ToggleCountryMainRegionSurface(newCountryIndex,true, _flagProvider.getFlag(newCountry.Flag));
            //TODO: This graphical effect appears to be buggy.
        }
        public void SpawnNewCountry(ProvinceIdentifier id, GameCountry newCountry)
        {
            Debug.Assert(id != null);
            Debug.Assert(newCountry != null);
            Debug.Log("Spawning new country "  + newCountry.Name + " from province  : " + id.Province);
            var formerProvince = _map.GetProvince (id.Province, id.Nation);
            _map.ProvinceToCountry (formerProvince, newCountry.Name);
            var newCountryIndex = _map.GetCountryIndex(_map.GetCountry(newCountry.Name));
            //_map.ToggleCountryMainRegionSurface(newCountryIndex,true, _flagProvider.getFlag(newCountry.Flag));
        }

    }
}