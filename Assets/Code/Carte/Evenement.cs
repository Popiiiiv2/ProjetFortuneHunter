using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartes
{
    [System.Serializable]
    public class Evenement : Carte
    {

        public override string getDescription()
        {
            return description;
        }

        public override string getTitre()
        {
            return titre;
        }

        public override string getType()
        {
            return type;
        }

        public override string getFichier()
        {
            return fichier;
        }

        public override string getAction()
        {
            return action;
        }

        public override int getValeur()
        {
            return valeur;
        }

        public override int getId()
        {
            return id;
        }
    }
}