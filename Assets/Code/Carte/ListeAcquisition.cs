using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class ListeAcquisition
    {
        public List<Acquisition> acquisition;

            public List<Acquisition> getListeAcquisition() {
            return acquisition;
        }

        public Acquisition tirerRandomAcquisition() {
            int random = Random.Range(0,getListeAcquisition().Count);
            Acquisition carte;
            carte = getListeAcquisition()[random];
            return carte;
        }
        public bool estVide() {
            return getListeAcquisition().Count == 0;
        }
        
        public void remplirPaquetAcquisition() {
            string assetsPath = Application.dataPath;
            string jsonFilePath = assetsPath + "\\code\\jsonDonnee\\acquisition.json";
            string jsonAcq = File.ReadAllText(jsonFilePath);
            ListeAcquisition acquisitions =  JsonUtility.FromJson<ListeAcquisition>(jsonAcq);
            for(int i=0;i<acquisitions.getListeAcquisition().Count;i++) {
                acquisition.Add(acquisitions.getListeAcquisition()[i]);
            }

        }

        public void retirerElementPaquetEmail(ListeAcquisition acquisitions, int index) {
            if (!acquisitions.estVide()) {
                acquisitions.getListeAcquisition().RemoveAt(index);
            }
        }
    }
}