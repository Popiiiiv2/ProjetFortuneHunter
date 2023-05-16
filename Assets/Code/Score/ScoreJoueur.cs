using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class ScoreJoueur : Score
{
        private CarteData inventaire;
        private const int MONTANT_INITIAL = 650;
        private const int PAYE = 1500;

        public ScoreJoueur() {
            montant = MONTANT_INITIAL;
            inventaire = null;
        }

        public CarteData getInventaire() {
            return inventaire;
        }

        public void setInventaire(CarteData carte) {
            inventaire = carte;
        }

        public void obtenirPaye(){
            montant += PAYE;
        }

        public bool estVide() {
            return inventaire == null;
        }

        public void viderInventaire() {
            inventaire = null;
        }

        public override string ToString() {
            return montant+" €";
        }

        public string inventaireToString() {
            if (!estVide()) {
                return "Inventaire :\n"+getInventaire().getDescription();
            } else {
                return "Inventaire vide !";
            }
        }
}
