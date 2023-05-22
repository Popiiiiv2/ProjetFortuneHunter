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
    private bool tourFini;
    private int moisActuel;
    private CarteControleur paquet;
    private HudJoueur hudJoueur;
    private string prefabName;
    private const float TEMPS_ATTENTE = 0.2f;
    private const int NB_JOUR_MAX = 31;
    private string nomJoueur;

    public IEnumerator effectuerUnTour()
    {
        tourFini = false;
        de.lancerDe();
        while (de.getValeurDe() == 0)
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        if (de.getValeurDe() == 6)
        {
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
    }
    //tour du joueur
    IEnumerator deplacerJoueur(int numCaseFinale)
    {
        CarteData carteData = new CarteData();
        int numCasePlateauSuivante = casePlateau.getNumCase() + 1;
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        for (int i = numCasePlateauSuivante; i <= numCaseFinale; i++)
        {
            Case caseSuivante = plateau.getCase(i);
            this.transform.position = caseSuivante.transform.position;
            yield return new WaitForSeconds(TEMPS_ATTENTE);
        }
        casePlateau = plateau.getCase(numCaseFinale);
        if (numCaseFinale == NB_JOUR_MAX)
        {
            hudJoueur.obtenirPaye();
        }
        Debug.Log(casePlateau.getTypeCase());
        if (casePlateau.getTypeCase() == TypeCase.BROCANTE && !hudJoueur.getScore().estVide())
        {
            carteData = hudJoueur.getScore().getInventaire();
            carteData.setAction("Gain");
            afficherCarte.chargerPrefab(carteData);
            afficherCarte.afficherTexteCarte(carteData);

        }
        else if (casePlateau.getTypeCase() == TypeCase.PARI_SPORTIF)
        {
            paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
            carteData = paquet.tirerRandomCarte();
            afficherCarte.chargerPrefab(carteData);
            afficherCarte.afficherTexteCarte(carteData);
            pariSportif(carteData);
        }
        else
        {
            paquet = jeu.paquets.getPaquet(casePlateau.getTypeCase());
            carteData = paquet.tirerRandomCarte();
            afficherCarte.chargerPrefab(carteData);
            afficherCarte.afficherTexteCarte(carteData);
        }
        while (estActionJouer())
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            Debug.Log(estActionJouer());
        }
        if (jeu.getAction() != "Annuler")
        {
            hudJoueur.setScore(carteData);
        }
        yield return new WaitForSeconds(TEMPS_ATTENTE);
        tourFini = true;
        jeu.setAction(null);
    }

    public Case getCase()
    {
        return this.casePlateau;
    }

    public bool isTourFini()
    {
        return tourFini;
    }

    public HudJoueur getHudJoueur()
    {
        return hudJoueur;
    }

    public int getMoisMax()
    {
        return moisActuel;
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public int getArgent()
    {
        return hudJoueur.getScore().getMontant();
    }

    public void setNomJoueur(string s)
    {
        nomJoueur = s;
    }

    public string getNomJoueur()
    {
        return nomJoueur;
    }

    public bool estActionJouer()
    {
        return jeu.getAction() == null;
    }

    public IEnumerator pariSportif(CarteData carteData)
    {
        Cagnotte pari = new Cagnotte();
        pari.setMontant(1000);
        afficherCarte.chargerPrefab(carteData);
        while (estActionJouer())
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            Debug.Log(estActionJouer());
        }
        bool[] valider = jeu.getValider();
        hudJoueur.getAction().participerPari(pari, valider, jeu.getJoueurs());
        NewDice dePari = new NewDice();
        while (dePari.getValeurDe() > 4 && !valider[dePari.getValeurDe()])
        {
            while (dePari.getValeurDe() == 0)
            {
                yield return new WaitForSeconds(TEMPS_ATTENTE);
            }
            dePari.lancerDe();
        }
        hudJoueur.getAction().gagnerCagnotte(jeu.getJoueurs()[dePari.getValeurDe()].hudJoueur.getScore(), pari);

    }
}