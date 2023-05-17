using System.Collections.Generic;

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