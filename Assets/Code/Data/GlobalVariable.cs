using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    private int nbMois;

    private int nbJoueur;

    private string[] nomJoueur;

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

    public void setNomJoueur(int index, string nom)
    {
        nomJoueur[index] = nom;
    }

    public string getNomJoueur(int index)
    {
        return nomJoueur[index];
    }

    public void setNbMois(string Mois)
    {
        this.nbMois = int.Parse(Mois);
    }

    public int getNbMois()
    {
        return nbMois;
    }

    public void setNbJoueur(string nbJoueur)
    {
        this.nbJoueur = int.Parse(nbJoueur);
        nomJoueur = new string[this.nbJoueur];
    }

    public int getNbJoueur()
    {
        return nbJoueur;
    }

    public void setJoueur(Joueur[] j)
    {
        joueurs = j;
    }

    public Joueur[] GetJoueurs()
    {
        return joueurs;
    }

}
