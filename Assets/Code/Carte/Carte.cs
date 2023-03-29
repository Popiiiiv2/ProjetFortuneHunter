using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carte 
{
    public abstract class Carte
    {
        public override string getDescription();

        public override string getTitre();

        public override string getType();

        public override string getFichier();

        public override string getAction();

        public override int getValeur();

        public override int getId();
    
        public override int getVente();

    }
}