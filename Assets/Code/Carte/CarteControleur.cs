using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Cartes
{
    public class CarteControleur
    {
        private string cheminDossier;
        public CarteDataList paquet;

        public CarteControleur()
        {
            paquet = new CarteDataList();
            cheminDossier = Application.dataPath + "\\code\\jsonDonnee\\";
        }

        // void Start()
        // {
        //     cheminDossier = Application.dataPath + "\\code\\jsonDonnee\\";
        //     nouveauPaquet(TypeCase.EVENEMENT);
        //     Debug.Log(tirerRandomCarte().getType());
        //     nouveauPaquet(TypeCase.MAIL);
        //     Debug.Log(tirerRandomCarte().getType());
        //     nouveauPaquet(TypeCase.BROCANTE);
        //     Debug.Log(this.paquet.getList()[0].getType());
        //     Debug.Log(tirerRandomCarte().getType());
        //     Debug.Log(tirerRandomCarte().getType());
        //     Debug.Log(tirerRandomCarte().getType());
        //     Debug.Log(tirerRandomCarte().getType());
        //     Debug.Log(tirerRandomCarte().getType());
        //     Debug.Log(estVide());
        // }
        //Génère un nouveau paquet en fonction du type passer en param
        public void nouveauPaquet(TypeCase type)
        {
            string jsonContenu;
            switch (type)
            {
                case TypeCase.EVENEMENT:
                    jsonContenu = File.ReadAllText(cheminDossier + "evenement.json");
                    paquet = JsonUtility.FromJson<CarteDataList>(jsonContenu);
                    break;
                case TypeCase.BROCANTE:
                    jsonContenu = File.ReadAllText(cheminDossier + "brocante.json");
                    paquet = JsonUtility.FromJson<CarteDataList>(jsonContenu);
                    break;
                case TypeCase.MAIL:
                    jsonContenu = File.ReadAllText(cheminDossier + "email.json");
                    paquet = JsonUtility.FromJson<CarteDataList>(jsonContenu);
                    break;
                default: break;
            }
        }

        // Tire une carte dans le paquet de manière aléatoire
        public CarteData tirerRandomCarte()
        {
            int random = Random.Range(0, paquet.getList().Count);
            CarteData carte;
            carte = paquet.getList()[random];
            retirerCartePaquet(random);
            return carte;
        }

        // Supprime une carte du paquet
        private void retirerCartePaquet(int index)
        {
            if (!estVide())
            {
                paquet.getList().RemoveAt(index);
            }
        }
        // Renvoie vrai si un paquet est vide
        public bool estVide()
        {
            return paquet.getList().Count == 0;
        }
    }
}