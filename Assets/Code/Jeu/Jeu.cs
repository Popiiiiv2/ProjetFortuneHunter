using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class Jeu : MonoBehaviour
{
    private Plateau plateau;
    private Joueur joueur;
    public CarteVue paquets;
    private GlobalVariable globalVars;
    private int nbMois = 1;
    private const float TEMPS_ATTENTE = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // Pour la selection du nombre de mois
        // globalVars = FindObjectOfType<GlobalVariable>();
        // nbMois = globalVars.getNbMois();
        plateau = GameObject.Find("Plateau").GetComponent<Plateau>();
        joueur = GameObject.Find("Pions").GetComponent<Joueur>();
        paquets = new CarteVue();
        plateau.setNumCase();
        StartCoroutine(jouerPartie());
    }

    IEnumerator jouerPartie()
    {
        for (int i = 1; i <= nbMois; i++)
        {
            joueur.caseDepart();
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            do
            {
                joueur.lancerDe();
                do
                {
                    yield return new WaitForSeconds(TEMPS_ATTENTE);
                } while (!joueur.isTourFini());
            }
            while (joueur.getCase().getNumCase() < 31);
            print("Tour " + i + " fini");
        }
        print("Partie Finie");
    }

}
