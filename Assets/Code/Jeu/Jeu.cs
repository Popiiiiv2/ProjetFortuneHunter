using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private Plateau plateau;
    public Joueur joueur;
    public static int NOMBRE_DE_MOIS = 4;
    private const float TEMPS_ATTENTE = 2f;
    // Start is called before the first frame update
    void Start()
    {
        plateau = GameObject.Find("Plateau").GetComponent<Plateau>();
        plateau.setNumCase();
        StartCoroutine(jouerPartie());
    }

    IEnumerator jouerPartie() {
        for(int i = 1; i <= NOMBRE_DE_MOIS; i++){
            joueur.caseDepart();
            yield return new WaitForSeconds(TEMPS_ATTENTE);
            do{
                joueur.lancerDe();
                do{
                    yield return new WaitForSeconds(TEMPS_ATTENTE);
                } while(!joueur.isTourFini());    
            }
            while (joueur.getCase().getNumCase() < 31);
            print("Tour "+i+" fini");
        }
        print("Partie Finie");
    }

}
