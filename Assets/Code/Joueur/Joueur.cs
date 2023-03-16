using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur
{

    private Case casePlateau;
	private Plateau plateau;
	private string couleur;
	private De de;

    public Joueur(Plateau plateau, string couleur, De de) {
        this.plateau = plateau;
        this.couleur = couleur;
        this.de = de;
        this.casePlateau = plateau.caseDebutPartie();
    }

    public int lancer() {
        return de.lancer();
    }

    //permet au joueur de se déplacer (lance le dé et avance le pion)
    public void deplacement(){
        Case NouvelleCasePlateau = casePlateau.depart(this);
        this.casePlateau = NouvelleCasePlateau;
    }

    public Plateau getPlateau() {
        return plateau;
    }

    public Case getCase(){
        return this.casePlateau;
    }

    public bool partieFini(){
        return casePlateau.getNumCase() >= 31;
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
