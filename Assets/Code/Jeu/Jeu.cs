using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class Jeu : MonoBehaviour
{
    private Plateau plateau;
    private Joueur[] joueurs;
    public PaquetsCartes paquets;
    private GlobalVariable globalVars;
    private int nbMois = 1;
    private const float TEMPS_ATTENTE = 2f;
    // Start is called before the first frame update
    void Start()
    {
        globalVars = FindObjectOfType<GlobalVariable>();
        nbMois = globalVars.getNbMois();
        // initialisation du nombre de joueurs
        int nbJoueur = globalVars.getNbJoueur();
        joueurs = new Joueur[nbJoueur];
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

                joueurs[i].initialiserScoreJoueur(hud);
            } else {
                j.SetActive(false);
                gm.SetActive(false);
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

            j.lancerDe();
            do{
                yield return new WaitForSeconds(TEMPS_ATTENTE);
            } while (!j.isTourFini());
            if(j.getCase().getNumCase() == 31){
                print("Tour " + j.getMoisMax() + " fini par le joueur " + tourDuJoueur+1);
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


}
