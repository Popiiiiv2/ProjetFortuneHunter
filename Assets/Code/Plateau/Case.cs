using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case
{

    private int numCase;
    private string libelle;
    private TypeCase type;
    private const int JOUR_MAX = 31;

    public Case(int numCase){
        this.numCase = numCase;
    }

    //recupère la case de départ du joueur et lance le dé
    //return la case d'arrivée
    public Case depart(Joueur joueur){
        int lancerDe = joueur.lancer();
        int numCaseSuivante = numCase + lancerDe;
        return caseSuivante(joueur, numCaseSuivante);
    }

    //retourne la case d'arrivée du joueur après le lancer de dé
    private Case caseSuivante(Joueur joueur, int numCaseSuivante) {
        if(numCaseSuivante > JOUR_MAX) {
            numCaseSuivante = JOUR_MAX;
        }
		Plateau plateau = joueur.getPlateau();
		Case caseDestination = plateau.getCase(numCaseSuivante);
		return caseDestination;
	}

    public string toString() {
        return "Il s'agit de la Case n° "+numCase;
    }

    public int getNumCase(){
        return numCase;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
