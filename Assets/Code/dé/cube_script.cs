using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_script : MonoBehaviour
{

    System.Random rnd = new System.Random();
    public int face;
    //change la rotation du de juste au début
    void Start()
    {
        transform.Rotate(new Vector3 (rnd.Next(100,500),rnd.Next(100,500),rnd.Next(100,500)));
        transform.Translate(new Vector3 (2,5,-1));

    }

    //change la rotation du de quand on appuie sur espace
    void Update()
    {
        // Si l'utilisateur appuie sur le bouton "Espace"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Génère une rotation aléatoire et applique-la à l'objet
            transform.Rotate(new Vector3(rnd.Next(100, 500), rnd.Next(100, 500), rnd.Next(100, 500)));
        }
    }
}
