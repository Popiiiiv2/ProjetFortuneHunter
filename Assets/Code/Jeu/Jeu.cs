using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class Jeu : MonoBehaviour
{
    public Plateau plateau;
    public Joueur joueur;
    public CarteControleur evenement;
    public CarteControleur mail;
    public CarteControleur brocante;

    public int a = 10;
    public static int NOMBRE_DE_MOIS = 4;
    private const float TEMPS_ATTENTE = 2f;
    // Start is called before the first frame update
    void Start()
    {
        joueur.donnerPaquet(a);
        print(a);
        plateau.setNumCase();
        StartCoroutine(jouerPartie());
    }

    IEnumerator jouerPartie()
    {
        for (int i = 1; i <= NOMBRE_DE_MOIS; i++)
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
