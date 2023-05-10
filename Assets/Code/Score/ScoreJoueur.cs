using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class ScoreJoueur : Score
{
        public List<CarteData> inventaire = new List<CarteData>();


        public List<CarteData> getInventaire() {
            return inventaire;
        }

        public override string ToString() {
        return "Score : "+montant+" €";
    }

}
