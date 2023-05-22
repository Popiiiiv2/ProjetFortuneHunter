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
                    btn.onClick.AddListener(() => annulerEvenement(obj));
                    break;
                case "Parier":
                    btn = obj.GetComponent<Button>();
                    btn.onClick.AddListener(() => pariSportif(obj));
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
        Debug.Log("Valider");
        jeu.setAction("Valider");
        destroyObjet();
    }

    private void vendreEvenement(GameObject obj)
    {
        Debug.Log("Vendre");
        jeu.setAction("Vendre");
        destroyObjet();
    }

    private void acheterEvenement(GameObject obj)
    {
        Debug.Log("Acheter");
        jeu.setAction("Acheter");
        destroyObjet();
    }

    private void annulerEvenement(GameObject obj)
    {
        Debug.Log("Annuler");
        jeu.setAction("Annuler");
        destroyObjet();
    }

    private void pariSportif(GameObject obj)
    {
        Debug.Log("Lancer Pari");
        foreach (GameObject ob in objects)
        {
            bool tog;
            string name = ob.name;
            switch (name)
            {
                case "TogglePlayer1":
                    tog = obj.GetComponent<Toggle>().isOn;
                    jeu.setValider(1, tog);
                    break;
                case "TogglePlayer2":
                    tog = obj.GetComponent<Toggle>().isOn;
                    jeu.setValider(2, tog);
                    break;
                case "TogglePlayer3":
                    tog = obj.GetComponent<Toggle>().isOn;
                    jeu.setValider(3, tog);
                    break;
                case "TogglePlayer4":
                    tog = obj.GetComponent<Toggle>().isOn;
                    jeu.setValider(4, tog);
                    break;
            }
        }
        jeu.setAction("Parier");
        destroyObjet();
    }
}