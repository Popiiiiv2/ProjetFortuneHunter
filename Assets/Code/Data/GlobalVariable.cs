using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    private int nbMois;

    private int nbJoueur;

    private static GlobalVariable instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setNbMois(string Mois){
        this.nbMois = int.Parse(Mois);
    }

    public int getNbMois(){
        return nbMois;
    }

    public void setNbJoueur(string nbJoueur){
        this.nbJoueur = int.Parse(nbJoueur);
    }

    public int getNbJoueur(){
        return nbJoueur;
    }
    
}
