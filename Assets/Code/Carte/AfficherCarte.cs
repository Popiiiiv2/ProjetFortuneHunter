using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cartes;

public class AfficherCarte : MonoBehaviour
{
    public GameObject prefabObjetCarte;
    public GameObject prefabObjetBrocante;
    public GameObject prefabObjetJoueur;
    private string prefabName;

    public void chargerPrefab(CarteData carteData)
    {
        GameObject nouvelObjet;
        switch (carteData.getType())
        {
            case "Brocante":
                nouvelObjet = Instantiate(prefabObjetBrocante);
                prefabName = "PrefabCarteBrocante(Clone)";
                break;
            case "Pari":
                nouvelObjet = Instantiate(prefabObjetCarte);
                prefabName = "PrefabCarte(Clone)";
                break;
            default:
                nouvelObjet = Instantiate(prefabObjetCarte);
                prefabName = "PrefabCarte(Clone)";
                break;
        }
    }

    public void supprimerPrefab()
    {
        GameObject objetASupprimer = GameObject.Find(prefabName);
        if (objetASupprimer != null)
        {
            Destroy(objetASupprimer, 2);
        }
        else
        {
            Debug.LogError("L'objet à supprimer n'a pas été trouvé dans la scène.");
        }
    }

    private void descriptionCarte(string description)
    {
        GameObject textObject = GameObject.Find("Carte_text");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = description;
    }

    private void titleCarte(string title)
    {
        GameObject textObject = GameObject.Find("CarteTitle_text");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = title;
    }

    private void actionCarte(string action)
    {
        GameObject textObject = GameObject.Find("CarteAction_text");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = "Gain : " + action;
    }

    public void afficherTexteCarte(CarteData carteData)
    {
        string text;
        titleCarte(carteData.getType());
        descriptionCarte(carteData.getDescription());
        switch (carteData.getAction())
        {
            case "Gain":
                text = "Gagner : " + carteData.getValeur();
                actionCarte(text);
                break;
            case "Perte":
                text = "Payer : " + carteData.getValeur();
                actionCarte(text);
                break;
            default:
                text = "";
                actionCarte(text);
                break;
        }
    }
}