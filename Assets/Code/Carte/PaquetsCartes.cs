using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class PaquetsCartes
    {
        public List<Carte> paquet;
        private string typeCarte;
        private string jsonDossier = Application.dataPath + "\\code\\jsonDonnee\\";
        public PaquetsCartes()
        {
            paquet = new List<Carte>();
        }

        public List<Carte> getPaquet()
        {
            return paquet;
        }

        public void setPaquetCarte()
        {
            string jsonContenu = File.ReadAllText(jsonDossier + "evenement.json");
            PaquetsCartes paquetsCarte = JsonUtility.FromJson<PaquetsCartes>(jsonContenu);
            Debug.Log(paquetsCarte.getPaquet().Count);
            for (int i = 0; i < paquetsCarte.getPaquet().Count; i++)
            {
                Debug.Log(i);
                paquet.Add(paquetsCarte.getPaquet()[i]);
            }
        }

        public void retirerElementPaquetEvenement(int index)
        {
            if (estVide())
            {
                paquet.RemoveAt(index);
            }
        }

        public bool estVide()
        {
            return paquet.Count == 0;
        }
    }
}