using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class Email : Carte
    {
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

        public string getAction()
        {
            return action;
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