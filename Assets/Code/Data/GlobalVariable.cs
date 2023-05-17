using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    private int nbMois;

    private int nbJoueur;

    private Joueur[] joueurs;

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

    public void setJoueur(Joueur[] j){
        joueurs = j;
    }

    public Joueur[] GetJoueurs(){
        return joueurs;
    }
    
}
