using System.Collections;
using UnityEngine;
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
    private const float TEMPS_ATTENTE = 0.2f;
    private const int NB_JOUR_MAX = 31;
    private string nomJoueur;
    private bool finAction;

    //effectuer un tour
    public IEnumerator effectuerUnTour()
    {
        tourFini = false;
        de.lancerDe();

        // attendre la fin du lancer de dé
        while (de.getValeurDe() == 0)
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }

        // si il tombe sur 6, il récupère l'argent de la cagnotte
        if(de.getValeurDe() == 6){
            recupererCagnotte();
        }

        finAction = false;
        avancer(de.getValeurDe());
        while(!finAction){
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }

        finAction = false;
        StartCoroutine(piocherCarte());
        while(!finAction){
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        tourFini = true;
    }

    //récupère l'argent de la cagnotte et met la cagnotte à 0
    private void recupererCagnotte(){
        int montantCagnotte = jeu.getCagnotte().getMontant();
        hudJoueur.getArgentCagnotte(montantCagnotte);
        jeu.getCagnotte().reinitialiserCagnotte();
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
    }

    //déplace le joueur
    IEnumerator deplacerJoueur(int numCaseFinale)
    {        
        int numCasePlateauSuivante = casePlateau.getNumCase() + 1;
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        for (int i = numCasePlateauSuivante; i <= numCaseFinale; i++)
        {
            Case caseSuivante = plateau.getCase(i);
            this.transform.position = caseSuivante.transform.position;
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }

        casePlateau = plateau.getCase(numCaseFinale);
        if(numCaseFinale == NB_JOUR_MAX){
            hudJoueur.obtenirPaye();
        }
        finAction = true;
    }

    //pioche une carte et effectue l'action
    IEnumerator piocherCarte(){
        CarteData carteData = new CarteData();
        paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
        carteData = paquet.tirerRandomCarte();
        afficherCarte.chargerPrefab(carteData);
        afficherCarte.afficherTexteCarte(carteData);
        while (estActionJouer())
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        hudJoueur.setScore(carteData);
        jeu.setAction(null);
        finAction = true;
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

    public void InitialisationJoueur(Plateau p){
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
        return hudJoueur.getScore();
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
}
