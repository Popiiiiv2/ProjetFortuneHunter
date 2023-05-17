using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonCarte : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject carte;
    private Jeu jeu;

    void Start()
    {
        jeu = FindObjectOfType<Jeu>();
        AjouterEvenementBouton();
    }

    public void AjouterEvenementBouton()
    {
        foreach (GameObject obj in objects)
        {
            string nameButton = obj.name;
            Button btn;
            switch (nameButton)
            {
                case "Achat":
                    btn = obj.GetComponent<Button>();
                    btn.onClick.AddListener(() => acheterEvenement(obj));
                    break;
                case "Vente":
                    btn = obj.GetComponent<Button>();
                    btn.onClick.AddListener(() => vendreEvenement(obj));
                    break;
                case "Valide":
                    btn = obj.GetComponent<Button>();
                    btn.onClick.AddListener(() => validerEvenement(obj));
                    break;
                case "Annuler":
                    btn = obj.GetComponent<Button>();
                    btn.onClick.AddListener(() => validerEvenement(obj));
                    break;
            }
        }
    }

    private void destroyObjet()
    {
        Destroy(carte);
    }

    private void validerEvenement(GameObject obj)
    {
        jeu.setAction("Valider");
        destroyObjet();
    }

    private void vendreEvenement(GameObject obj)
    {
        jeu.setAction("Vendre");
        destroyObjet();
    }

    private void acheterEvenement(GameObject obj)
    {
        jeu.setAction("Acheter");
        destroyObjet();
    }

    private void annulerEvenement(GameObject obj)
    {
        jeu.setAction("Annuler");
        destroyObjet();
    }
}