using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Cartes;
using UnityEngine.UI;

public class HudJoueur : MonoBehaviour
{
    private ScoreJoueur scoreJoueur;
    private Text text;
    private Action action;
    private Jeu jeu;
    private Text textAcquisition;

    public void initialiserScoreJoueur(string score, string textAcqui){
        this.scoreJoueur = new ScoreJoueur();
        text = GameObject.Find(score).GetComponent<Text>();
        text.text = scoreJoueur.ToString();
        textAcquisition = GameObject.Find(textAcqui).GetComponent<Text>();
        textAcquisition.text = scoreJoueur.inventaireToString();
        action = new Action();
    }

    public void setScore(CarteData carteData)
    {
        Cagnotte cagnotte = jeu.getCagnotte();
        if (carteData.getType() == "Email" || carteData.getType() == "Event") {
            action.actionCarte(scoreJoueur, cagnotte, carteData);
        } else if (carteData.getType() == "Brocante") {
            if (!scoreJoueur.estVide()) {
                action.vente(scoreJoueur);
            } else {
                action.achat(scoreJoueur, carteData);
            }
        }
        miseAJourDesScores();
    }

    public void miseAJourDesScores(){
        text.text = scoreJoueur.ToString();
        textAcquisition.text = scoreJoueur.inventaireToString();
    }

    public void setJeu(Jeu jeu)
    {
        this.jeu = jeu;
    }

    public ScoreJoueur getScore(){
        return scoreJoueur;
    }

    public void obtenirPaye()
    {
        scoreJoueur.obtenirPaye();
        miseAJourDesScores();
    }

    public void getArgentCagnotte(int argentCagnotte){
        scoreJoueur.setMontant(scoreJoueur.getMontant() + argentCagnotte);
    }
}