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

    public void afficherTexteCarte(CarteData carteData)
    {
        GameObject textObject = GameObject.Find("Carte_text");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = carteData.getDescription();

        textObject = GameObject.Find("CarteTitle_text");
        composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = carteData.getType();

        textObject = GameObject.Find("CarteAction_text");
        composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = "Gain : " + carteData.getValeur();

        switch (carteData.getAction())
        {
            case "Gain":
                composantTexte.text = "Gagner : " + carteData.getValeur();
                break;
            case "Perte":
                composantTexte.text = "Payer : " + carteData.getValeur();
                break;
            default:
                composantTexte.text = "";
                break;
        }
    }
}