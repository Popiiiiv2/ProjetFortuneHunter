using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public Plateau plateau;
    public Joueur joueur;
    // Start is called before the first frame update
    void Start()
    {
        plateau.setNumCase();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            joueur.deplacement();
            System.Threading.Thread.Sleep(100);
        }
    }
}
