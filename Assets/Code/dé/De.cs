using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class De : MonoBehaviour
{

    System.Random rnd = new System.Random();
    public int face;
    private bool deLancer = false;

    //change la rotation du de quand on appuie sur espace
    void Update()
    {
        // Si l'utilisateur appuie sur le bouton "Espace"
        if (Input.GetKeyDown(KeyCode.Space) && deLancer)
        {
            // Génère une rotation aléatoire et applique-la à l'objet
            transform.Rotate(new Vector3(rnd.Next(100, 500), rnd.Next(100, 500), rnd.Next(100, 500)));
            deLancer = false;        
        }
    }

    public void lancerDe(Joueur joueur){
        deLancer = true;
        StartCoroutine(attendreFinLancerDe(joueur));
    }

    IEnumerator attendreFinLancerDe(Joueur joueur){
        do{
            yield return new WaitForSeconds(3);
        } while(deLancer);
        joueur.avancer(face);
    }
}
