using System;
using UnityEngine;

namespace CustomAssets.CustomScripting.types
{
    public class FlagProvider : MonoBehaviour
    {

        [Header("Flags")]
        public Texture2D ironCanadaFlag;
        public Texture2D brimstoneTexasFlag;
        public Texture2D paisDelDiabloFlag;
        public Texture2D siliconCrevasseFlag;


        public Texture2D getFlag(Flag flag)
        {
            switch (flag)
            {
                case Flag.IRON_CANADA:
                    return ironCanadaFlag;
                case Flag.SILICON_CREVASSE:
                    return siliconCrevasseFlag;
                case Flag.PAIS_DEL_DIABLO:
                    return paisDelDiabloFlag;
                case Flag.BRIMSTONE_TEXAS:
                    return brimstoneTexasFlag;
            }
            throw new Exception("Could not get flag for country! " + flag);
        }
    }
}