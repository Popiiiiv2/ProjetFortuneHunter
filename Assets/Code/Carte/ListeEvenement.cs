using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class ListeEvenement
    {
        public List<Evenement> evenement;

        public List<Evenement> getListeEvenement()
        {
            return evenement;
        }

        public Evenement tirerRandomEvenement()
        {
            int random = Random.Range(0, getListeEvenement().Count);
            Evenement carte;
            carte = getListeEvenement()[random];
            return carte;
        }
        public bool estVide()
        {
            return getListeEvenement().Count == 0;
        }

        public void remplirPaquetEvenement()
        {
            string assetsPath = Application.dataPath;
            string jsonFilePath = assetsPath + "\\code\\jsonDonnee\\evenement.json";
            string jsonEvenement = File.ReadAllText(jsonFilePath);
            ListeEvenement evenements = JsonUtility.FromJson<ListeEvenement>(jsonEvenement);
            Debug.Log(evenements);
            for (int i = 0; i < evenements.getListeEvenement().Count; i++)
            {
                evenement.Add(evenements.getListeEvenement()[i]);
            }
        }

        public void retirerElementPaquetEvenement(ListeEvenement evenements, int index)
        {
            if (!evenements.estVide())
            {
                evenements.getListeEvenement().RemoveAt(index);
            }
        }

    }
}