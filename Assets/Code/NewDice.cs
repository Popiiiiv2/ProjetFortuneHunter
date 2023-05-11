using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDice : MonoBehaviour
{
    public Button yourButton;

    public float disableTime = 4f;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        int diceNumber = Random.Range(1, 7); //il faut récupérer cette valeur pour la mettre dans de à la place de face
        if (diceNumber==7)
            {
            disableTime = 7f;
            }
         if (diceNumber==6)
            {
            disableTime = 6f;
            }
         if (diceNumber==5)
            {
            disableTime = 5f;
            }
        GameObject textObject = GameObject.Find("NombreDe");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = diceNumber.ToString();

        Debug.Log(diceNumber); // Affiche le résultat dans la console Unity

        yourButton.interactable = false; // Désactive le bouton
        Invoke("EnableButton", disableTime); // Réactive le bouton après un délai
 
    }

     void EnableButton()
    {
        yourButton.interactable = true; // Réactive le bouton
    }
}






