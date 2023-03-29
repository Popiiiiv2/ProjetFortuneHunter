using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{

    public Plateau plateau;
    private Case casePlateau;
    private bool enDeplacement = false;
    public De de;

    //permet au joueur de se déplacer (lance le dé et avance le pion)
    public void deplacement(){
        if(!enDeplacement) {
            enDeplacement = true;
            casePlateau = casePlateau.depart(this);
        }       
    }

    public void setEnDeplacement() {
        enDeplacement = false;
    }

    public Case getCase(){
        return this.casePlateau;
    }

    /*public int lancerDe(){
        de.lancer();
    }*/

    public void deplacerJoueur(Case caseDestination){
        this.transform.position = caseDestination.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.casePlateau = plateau.caseDebutPartie();
    }
}
