using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDice : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        int diceNumber = Random.Range(1, 7);

        GameObject textObject = GameObject.Find("NombreDe");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = diceNumber.ToString();

        Debug.Log(diceNumber); // Affiche le résultat dans la console Unity

    }
}






