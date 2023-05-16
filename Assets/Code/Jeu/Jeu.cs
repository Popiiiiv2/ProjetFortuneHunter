using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;
using UnityEngine.SceneManagement;

public class Jeu : MonoBehaviour
{
    private Plateau plateau;
    private Joueur[] joueurs;
    public PaquetsCartes paquets;
    private List<GameObject> hudASupprimer = new List<GameObject>();
    private GlobalVariable globalVars;
    private int nbMois;
    private Cagnotte cagnotte;
    private const float TEMPS_ATTENTE = 1f;
    private const int NB_MAX_JOUEUR = 4;
    private const int NB_JOUR_MAX = 31;

    // Start is called before the first frame update
    void Start()
    {
        RecuperationDesVariables();
        // Initialisation de la cagnotte
        this.cagnotte = new Cagnotte();
        InitialisationDesJoueurs();
        InitialisationDesHud();
        CreationPlateau();
        //initialisation du paquet
        paquets = new PaquetsCartes();
        //lancer la partie
        StartCoroutine(jouerPartie());
    }

    //Jouer la partie
    IEnumerator jouerPartie()
    {
        int tourDuJoueur = 0;
        int moisActuel = 1;
        do
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            Joueur j = joueurs[tourDuJoueur];
            print("Tour du joueur: "+(tourDuJoueur+1));
            StartCoroutine(j.effectuerUnTour());
            do{
                yield return new WaitForSeconds(TEMPS_ATTENTE);
            } while (!j.isTourFini());
            if(SurCasePaye(j)){
                print("Tour " + j.getMoisMax() + " fini par le joueur " + (tourDuJoueur+1));
                j.caseDepart();
            }
            moisActuel = getMoisActuel(moisActuel, j);
            tourDuJoueur = tourJoueurSuivant(tourDuJoueur);
        } while (moisActuel <= nbMois);

        print("Partie Finie");
        afficherFinPartie();
    }

    public Cagnotte getCagnotte()
    {
        return cagnotte;
    }

    void Update(){
        foreach(GameObject gm in hudASupprimer){
            gm.SetActive(false);
        }
    }

    // initialisation du plateau
    public void CreationPlateau(){
        plateau = GameObject.Find("Plateau").GetComponent<Plateau>();
        plateau.setNumCase();
    }

    //récupération du nombre de joueurs et de mois
    public void RecuperationDesVariables(){          
        globalVars = FindObjectOfType<GlobalVariable>();
        nbMois = globalVars.getNbMois();
        int nbJoueur = globalVars.getNbJoueur();
        joueurs = new Joueur[nbJoueur];
    }

    // initialisation des joueurs
    public void InitialisationDesJoueurs(){
        for(int i = 0; i < NB_MAX_JOUEUR; i++){
            string str = "Joueur"+i;
            GameObject j = GameObject.Find(str);
            if(i < joueurs.Length){
                joueurs[i] = j.GetComponent<Joueur>();
                joueurs[i].caseDepart();
                joueurs[i].setNomJoueur("Joueur"+(i+1));
            } else {
                j.SetActive(false);
            }
        }
    }

    // initialisation des Huds Joueurs
    public void InitialisationDesHud(){
        for(int i =0; i < NB_MAX_JOUEUR; i++){
            string str = "HUDJ"+(i+1);
            GameObject gm = GameObject.Find(str);
            HudJoueur hud = gm.GetComponent<HudJoueur>();
            if(i < joueurs.Length) {
                str = "ScoreJoueur"+(i+1);
                hud.initialiserScoreJoueur(str);
                hud.setJeu(this);
                joueurs[i].initialiserScoreJoueur(hud);
            } else {
                hudASupprimer.Add(gm);
            }
        }
    }

    // Verifie si le joueur est sur la case Paye
    public bool SurCasePaye(Joueur j){
        return j.getCase().getNumCase() == NB_JOUR_MAX;
    }

    // Renvoie le mois maximal qui est joué
    public int getMoisActuel(int moisActuel, Joueur j){
        return Mathf.Max(moisActuel, j.getMoisMax());
    }

    // Récupère le score du joueur
    public int tourJoueurSuivant(int tourDuJoueur){
        return (tourDuJoueur + 1) % joueurs.Length;
    }

    public void afficherFinPartie(){
        globalVars = FindObjectOfType<GlobalVariable>();
        globalVars.setJoueur(joueurs);
        SceneManager.LoadScene("FinDeGame");
    }    
}

