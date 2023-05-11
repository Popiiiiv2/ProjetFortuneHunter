using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class Joueur : MonoBehaviour
{
    public Jeu jeu;
    public Plateau plateau;
    private Case casePlateau;
    private De de;
    private CamSwitch camSwitch;
    private bool tourFini;
    private int moisActuel;
    private HudJoueur hudJoueur;

    public void lancerDe()
    {
        tourFini = false;
        camSwitch.cameraDe();
        de.lancerDe(this);
    }

    public void avancer(int valeurDe)
    {
        print(valeurDe);
        camSwitch.cameraPlateau();
        int numCaseFinale = valeurDe + casePlateau.getNumCase();
        if (numCaseFinale >= 31)
        {
            numCaseFinale = 31;
            moisActuel++;
        }
        StartCoroutine(deplacerJoueur(numCaseFinale));
    }
    //tour du joueur
    IEnumerator deplacerJoueur(int numCaseFinale)
    {
        CarteData carteData = new CarteData();
        int numCasePlateauSuivante = casePlateau.getNumCase() + 1;
        yield return new WaitForSeconds(1);
        for (int i = numCasePlateauSuivante; i <= numCaseFinale; i++)
        {
            Case caseSuivante = plateau.getCase(i);
            this.transform.position = caseSuivante.transform.position;
            yield return new WaitForSeconds(0.5f);
        }
        casePlateau = plateau.getCase(numCaseFinale);
        print("Il tombe sur la case: " + casePlateau.getTypeCase());
        CarteControleur paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
        carteData = paquet.tirerRandomCarte();
        print(carteData.description);
        tourFini = true;
    }

    public Case getCase()
    {
        return this.casePlateau;
    }

    public bool isTourFini()
    {
        return tourFini;
    }

    public int getMoisMax(){
        return moisActuel;
    }

    // Start is called before the first frame update
    void Start()
    {
        caseDepart();
        camSwitch = GameObject.Find("CamManager").GetComponent<CamSwitch>();
        de = GameObject.Find("dice").GetComponent<De>();
        this.moisActuel = 1;
    }

    public void caseDepart()
    {
        this.casePlateau = plateau.caseDebutPartie();
        this.transform.position = casePlateau.transform.position;
    }

    public void initialiserScoreJoueur(HudJoueur hudJoueur){
        this.hudJoueur = hudJoueur;
    }
}
