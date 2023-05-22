using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cartes;

public class Joueur : MonoBehaviour
{
    public Jeu jeu;
    private Plateau plateau;
    public AfficherCarte afficherCarte;
    private Case casePlateau;
    private NewDice de;
    private bool tourFini;
    private int moisActuel;
    private CarteControleur paquet;
    private HudJoueur hudJoueur;
    private string prefabName;
    private const float TEMPS_ATTENTE = 0.2f;
    private const int NB_JOUR_MAX = 31;
    private string nomJoueur;
    private bool deplacementfini;

    public IEnumerator effectuerUnTour()
    {
        tourFini = false;
        de.lancerDe();
        while (de.getValeurDe() == 0)
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        if(de.getValeurDe() == 6){
            int montantCagnotte = jeu.getCagnotte().getMontant();
            hudJoueur.getArgentCagnotte(montantCagnotte);
            jeu.getCagnotte().reinitialiserCagnotte();
        }
        avancer(de.getValeurDe());
    }

    public void avancer(int valeurDe)
    {
        int numCaseFinale = valeurDe + casePlateau.getNumCase();
        if (numCaseFinale >= NB_JOUR_MAX)
        {
            numCaseFinale = NB_JOUR_MAX;
            moisActuel++;
        }
        StartCoroutine(deplacerJoueur(numCaseFinale));
        casePlateau = plateau.getCase(numCaseFinale);
        if(numCaseFinale == NB_JOUR_MAX){
            obtenirPaye();
        }
        StartCoroutine(tirerUneCarte());
    }

    //tour du joueur
    IEnumerator deplacerJoueur(int numCaseFinale)
    {
        deplacementfini = false;
        CarteData carteData = new CarteData();
        int numCasePlateauSuivante = casePlateau.getNumCase() + 1;
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        for (int i = numCasePlateauSuivante; i <= numCaseFinale; i++)
        {
            Case caseSuivante = plateau.getCase(i);
            this.transform.position = caseSuivante.transform.position;
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }  
        deplacementfini = true;
    }

    IEnumerator tirerUneCarte(){
        while(!deplacementfini){
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        CarteData carteData = new CarteData();
        if (casePlateau.getTypeCase() == TypeCase.BROCANTE && !hudJoueur.getScore().estVide()) {
            carteData = hudJoueur.getScore().getInventaire();
            carteData.setAction("Gain");
            afficherCarte.chargerPrefab(carteData);
            afficherCarte.afficherTexteCarte(carteData);

        } else {
            paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
            carteData = paquet.tirerRandomCarte();
            afficherCarte.chargerPrefab(carteData);
            afficherCarte.afficherTexteCarte(carteData);
        }
        while (estActionJouer())
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        if (jeu.getAction() != "Annuler") {
            hudJoueur.setScore(carteData);
        }
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        jeu.setAction(null);
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

    public int getMoisMax()
    {
        return moisActuel;
    }

    public void initialisationJoueur(Plateau p){
        plateau = p;
        caseDepart();
        de = GameObject.Find("Button").GetComponent<NewDice>();
        this.moisActuel = 1;
    }

    public void caseDepart()
    {
        this.casePlateau = plateau.caseDebutPartie();
        this.transform.position = casePlateau.transform.position;
    }

    public void initialiserScoreJoueur(HudJoueur hudJoueur)
    {
        this.hudJoueur = hudJoueur;
    }

    public int getArgent(){
        return hudJoueur.getScore().getMontant();
    }

    public void setNomJoueur(string s){
        nomJoueur = s;
    }

    public string getNomJoueur(){
        return nomJoueur;
    }
    
    public bool estActionJouer()
    {
        return jeu.getAction() == null;
    }

    public void obtenirPaye(){
        hudJoueur.obtenirPaye();
    }
}