using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;
using System;

public class Jeu : MonoBehaviour
{
    private Plateau plateau;
    private Joueur[] joueurs;
    public PaquetsCartes paquets;
    private List<GameObject> hudASupprimer = new List<GameObject>();
    private GlobalVariable globalVars;
    private int nbMois = 1;
    private Cagnotte cagnotte;
    private const float TEMPS_ATTENTE = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //récupération du nombre de joueurs et de mois
        globalVars = FindObjectOfType<GlobalVariable>();
        nbMois = globalVars.getNbMois();
        int nbJoueur = globalVars.getNbJoueur();
        joueurs = new Joueur[nbJoueur];

        this.cagnotte = new Cagnotte();
        for(int i = 0; i < 4; i++){
            // initialisation du joueur
            string str = "Joueur"+i;
            GameObject j = GameObject.Find(str);

            // initialisation du score
            str = "HUDJ"+(i+1);
            GameObject gm = GameObject.Find(str);
            HudJoueur hud = gm.GetComponent<HudJoueur>();
            if(i < nbJoueur) {
                joueurs[i] = j.GetComponent<Joueur>();
                joueurs[i].caseDepart();

                str = "ScoreJoueur"+(i+1);
                hud.initialiserScoreJoueur(str);
                hud.setJeu(this);
                joueurs[i].initialiserScoreJoueur(hud);
            } else {
                j.SetActive(false);
                hudASupprimer.Add(gm);
            }
            
        }
        // initialisation du plateau
        plateau = GameObject.Find("Plateau").GetComponent<Plateau>();
        paquets = new PaquetsCartes();
        plateau.setNumCase();
        StartCoroutine(jouerPartie());
    }

    IEnumerator jouerPartie()
    {
        int tourDuJoueur = 0;
        int moisMax = 1;
        do
        {
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            Joueur j = joueurs[tourDuJoueur];
            print("Tour du joueur: "+(tourDuJoueur+1));
            j.lancerDe();
            do{
                yield return new WaitForSeconds(TEMPS_ATTENTE);
            } while (!j.isTourFini());
            if(j.getCase().getNumCase() == 31){
                print("Tour " + j.getMoisMax() + " fini par le joueur " + (tourDuJoueur+1));
                j.caseDepart();
            }
            if(moisMax < j.getMoisMax()){
                moisMax = j.getMoisMax();
            }
            tourDuJoueur++;
            if(tourDuJoueur == joueurs.Length){
                tourDuJoueur = 0;
            }

        } while (moisMax <= nbMois);

        print("Partie Finie");
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
}
