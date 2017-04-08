using System.Collections;
using System.Collections.Generic;
using CustomAssets.CustomScripting.common.inject;

namespace CustomAssets.CustomScripting.types
{
    public class GameCountry
    {
        private string _name;
        private ArrayList _startingUsStates = new ArrayList();
        private ArrayList _startingMexicanStates = new ArrayList();
        private ArrayList _startingCanadianProvinces = new ArrayList();
        private Flag _flag;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ArrayList StartingUsStates
        {
            get { return _startingUsStates; }
            set { _startingUsStates = value; }
        }

        public ArrayList StartingMexicanStates
        {
            get { return _startingMexicanStates; }
            set { _startingMexicanStates = value; }
        }

        public ArrayList StartingCanadianProvinces
        {
            get { return _startingCanadianProvinces; }
            set { _startingCanadianProvinces = value; }
        }

        public Flag Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public static GameCountry IronCanada = new GameCountry()
        {
            _name = "Iron Canada",
            _startingUsStates = {"Washington", "Idaho"},
            _startingCanadianProvinces = {"Alberta", "British Columbia"},
            _flag = Flag.IRON_CANADA
        };

        public static GameCountry Texas = new GameCountry()
        {
            _name = "Brimstone Texas",
            _startingUsStates = {"Texas"},
            _flag = Flag.BRIMSTONE_TEXAS
        };

        public static GameCountry SiliconValley = new GameCountry()
        {
            _name = "Silicon Crevasse",
            _startingUsStates = {"California", "Oregon"},
            _flag = Flag.SILICON_CREVASSE
        };


        public static GameCountry DevilCountry = new GameCountry()
        {
            _name = "Pais del Diablo",
            _flag = Flag.PAIS_DEL_DIABLO
        };

        public static ArrayList GetStartingGameCountries()
        {
            return new ArrayList {IronCanada, Texas, SiliconValley, DevilCountry};
        }

        public List<ProvinceIdentifier> GetProvinceIdentifiers()
        {
            List<ProvinceIdentifier> items = new List<ProvinceIdentifier>();
            foreach (string state in StartingUsStates)
            {
                items.Add(new ProvinceIdentifier() {Province = state, Nation = "United States of America"});
            }
            foreach (string state in StartingCanadianProvinces)
            {
                items.Add(new ProvinceIdentifier() {Province = state, Nation = "Canada"});
            }
            foreach (string state in StartingMexicanStates)
            {
                items.Add(new ProvinceIdentifier() {Province = state, Nation = "Mexico"});
            }
            return items;
        }
    }

}