using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{

    public Plateau plateau;
    private string libelle;
    private TypeCase type;
    private int numCase;
    private const int JOUR_MAX = 31;
    private const float TEMPS_ATTENTE = 0.25f;


    //recupère la case de départ du joueur et lance le dé
    //return la case d'arrivée
    public Case depart(Joueur joueur){
        int lancerDe = Random.Range(1,7);
        print("Le joueur a fait "+lancerDe+", il avance donc de "+lancerDe+" cases");
        int numCaseSuivante = numCase + lancerDe;
        return caseSuivante(joueur, numCaseSuivante);
    }

    //retourne la case d'arrivée du joueur après le lancer de dé
    private Case caseSuivante(Joueur joueur, int numCaseSuivante) {
        if(numCaseSuivante > JOUR_MAX) {
            numCaseSuivante = JOUR_MAX;
        }    
        StartCoroutine(deplacement(joueur, numCaseSuivante));
        //caseDestination = plateau.getCase(numCaseSuivante);
		return plateau.getCase(numCaseSuivante);
	}

    IEnumerator deplacement(Joueur joueur, int numCaseSuivante){
        for(int i = numCase; i <= numCaseSuivante; i++){ 
            joueur.deplacerJoueur(plateau.getCase(i));  
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        } 
        joueur.setEnDeplacement();           
    }

    public void setNumCase(int numCase){
        this.numCase = numCase;
    }

    public int getNumCase(){
        return numCase;
    }
}
