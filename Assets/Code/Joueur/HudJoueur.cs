using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cartes;

public class HudJoueur : MonoBehaviour
{
    private ScoreJoueur scoreJoueur;
    private TextMeshProUGUI text;
    private Action action;
    private Cagnotte cagnotte;

    public void initialiserScoreJoueur(string str){
        this.scoreJoueur = new ScoreJoueur();
        text = GameObject.Find(str).GetComponent<TextMeshProUGUI>();
        text.text = scoreJoueur.ToString();
        action = new Action();
        cagnotte = new Cagnotte();
    }

    public void setScore(CarteData carteData) {
        action.actionCarte(scoreJoueur, cagnotte, carteData);
        text.text = scoreJoueur.ToString();
    }

}