using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class ScoreJoueur
{
        public List<CarteData> inventaire = new List<CarteData>();

        private int montant;

        private static int MONTANT_INITIAL = 650;

        public ScoreJoueur(){
            montant = MONTANT_INITIAL;
        }

        public List<CarteData> getInventaire() {
            return inventaire;
        }

        public override string ToString() {
            return montant+" €";
        }

        public void setMontant(int montant) {
            this.montant = montant;
        }

        public int getMontant(){
            return montant;
        }
}


