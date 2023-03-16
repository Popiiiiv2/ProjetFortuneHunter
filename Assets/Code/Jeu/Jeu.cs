using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private Joueur j;
    // Start is called before the first frame update
    void Start()
    {
        Plateau p = new Plateau();
        string jaune = "jaune";
        De de = new De();
        j = new Joueur(p, jaune, de);
        do{
            j.deplacement();
            Debug.Log(j.getCase().toString());
        } while(!j.partieFini());
        Debug.Log("PArtie fini");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
