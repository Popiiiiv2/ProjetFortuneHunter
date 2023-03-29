using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public Plateau plateau;
    public Joueur joueur;
    public static int NOMBRE_DE_MOIS = 4;
    private const float TEMPS_ATTENTE = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        plateau.setNumCase();
        StartCoroutine(jouerPartie());
    }

    IEnumerator jouerPartie() {
        for(int i = 1; i <= NOMBRE_DE_MOIS; i++){
            joueur.caseDepart();
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            do{
                joueur.deplacement();
                yield return new WaitForSeconds(TEMPS_ATTENTE);
            }
            while (joueur.getCase().getNumCase() < 31);
            print("Tour "+i+" fini");
        }
        print("Partie Finie");
    }
}
