using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cartes;

public class Joueur : MonoBehaviour
{
    public Jeu jeu;
    public Plateau plateau;
    public AfficherCarte afficherCarte;
    private Case casePlateau;
    private NewDice de;
    private CamSwitch camSwitch;
    private bool tourFini;
    private int moisActuel;
    private CarteControleur paquet;
    private HudJoueur hudJoueur;

    public void lancerDe()
    {
        tourFini = false;
        de.lancerDe(this);
    }

    public void avancer(int valeurDe)
    {
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
        paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
        carteData = paquet.tirerRandomCarte();
        afficherCarte.chargerPrefab(carteData);
        afficherCarte.afficherTexteCarte(carteData);
        print(carteData.description);
        afficherCarte.supprimerPrefab();
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

    // Start is called before the first frame update
    void Start()
    {
        caseDepart();
        camSwitch = GameObject.Find("CamManager").GetComponent<CamSwitch>();
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
}
