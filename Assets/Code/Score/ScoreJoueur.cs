using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class ScoreJoueur : MonoBehaviour
{
        public List<CarteData> inventaire = new List<CarteData>();

        private int montant;


        public List<CarteData> getInventaire() {
            return inventaire;
        }

        public override string ToString() {
        return "Score : "+montant+" €";
        }

        public void setMontant(int montant) {
            this.montant = montant;
        }

        public int getMontant(){
            return montant;
        }
}


