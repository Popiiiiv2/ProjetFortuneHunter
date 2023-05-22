using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Cartes;
using UnityEngine.UI;

public class HudJoueur : MonoBehaviour
{
    private ScoreJoueur scoreJoueur;
    private Text text;
    private Action action;
    private Jeu jeu;
    private Text textAcquisition;
    private GlobalVariable globalVariable;

    public void initialiserScoreJoueur(string score, string textAcqui)
    {
        initialisationScore();
        text = GameObject.Find(score).GetComponent<Text>();
        text.text = scoreJoueur.ToString();
        textAcquisition = GameObject.Find(textAcqui).GetComponent<Text>();
        textAcquisition.text = scoreJoueur.inventaireToString();
        action = new Action();
    }

    public void initialisationScore(){
        this.scoreJoueur = new ScoreJoueur();
    }

    public void setScore(CarteData carteData)
    {
        Cagnotte cagnotte = jeu.getCagnotte();
        if (carteData.getType() == "Email" || carteData.getType() == "Event")
        {
            action.actionCarte(scoreJoueur, cagnotte, carteData);
        }
        else if (carteData.getType() == "Brocante")
        {
            if (!scoreJoueur.estVide())
            {
                action.vente(scoreJoueur);
            }
            else
            {
                action.achat(scoreJoueur, carteData);
            }
        }
        miseAJourDesScores();
    }

    public void miseAJourDesScores()
    {
        if(text!= null && textAcquisition != null){
            text.text = scoreJoueur.ToString();
            textAcquisition.text = scoreJoueur.inventaireToString();
        }
    }

    public void setJeu(Jeu jeu)
    {
        this.jeu = jeu;
    }

    public ScoreJoueur getScore()
    {
        return scoreJoueur;
    }

    public void obtenirPaye()
    {
        scoreJoueur.obtenirPaye();
        miseAJourDesScores();
    }

    public void afficherNomJoueur(Joueur j, int i)
    {
        globalVariable = FindObjectOfType<GlobalVariable>();
        int nbJoueur = globalVariable.getNbJoueur();
        string objText = "NomJoueur" + i;
        GameObject obj = GameObject.Find(objText);
        Text text = obj.GetComponent<Text>();
        string nom = globalVariable.getNomJoueur(i - 1);
        if (nom == null || nom == "")
        {
            text.text = "Joueur " + i;
            j.setNomJoueur("Joueur " + i);
        }
        else
        {
            text.text = nom;
            j.setNomJoueur(nom);
        }
    }

    public void getArgentCagnotte(int argentCagnotte)
    {
        scoreJoueur.setMontant(scoreJoueur.getMontant() + argentCagnotte);
    }
}