using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Cartes
{
    [System.Serializable]
    public class CarteDataList
    {
        public List<CarteData> data;

        // Retourne la lise de carte
        public List<CarteData> getList()
        {
            return data;
        }
    }
}