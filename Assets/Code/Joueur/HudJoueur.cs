using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Cartes;

public class HudJoueur : MonoBehaviour
{
    private ScoreJoueur scoreJoueur;
    private TextMeshProUGUI text;
    private Action action;
    private Jeu jeu;

    public void initialiserScoreJoueur(string str){
        this.scoreJoueur = new ScoreJoueur();
        text = GameObject.Find(str).GetComponent<TextMeshProUGUI>();
        text.text = scoreJoueur.ToString();
        action = new Action();
    }

    public void setScore(CarteData carteData) {
        Cagnotte cagnotte = jeu.getCagnotte();
        action.actionCarte(scoreJoueur, cagnotte, carteData);
        text.text = scoreJoueur.ToString();
    }

    public void setJeu(Jeu jeu){
        this.jeu = jeu;
    }

}