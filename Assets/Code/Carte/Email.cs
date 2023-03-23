using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class Email
    {
        public string description, titre, type, fichier, action;
        public int valeur, id;

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