using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class Acquisition
    {
        public string description, titre, type, fichier;
        public int valeur, vente, id;

        public string getDescription()
        {
            return description;
        }

        public string getTitre()
        {
            return titre;
        }

        public string getType()
        {
            return type;
        }

        public string getFichier()
        {
            return fichier;
        }

        public int getVente()
        {
            return vente;
        }

        public int getValeur()
        {
            return valeur;
        }

        public int getId()
        {
            return id;
        }
    }
}