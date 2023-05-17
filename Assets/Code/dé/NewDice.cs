using UnityEngine;
using UnityEngine.UI;

public class NewDice : MonoBehaviour
{
    public Button yourButton;
    private int valeurDe;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        yourButton.interactable = false;
    }

    void TaskOnClick()
    {
        valeurDe = Random.Range(1, 7); //il faut récupérer cette valeur pour la mettre dans de à la place de face
        GameObject textObject = GameObject.Find("NombreDe");
        Text composantTexte = textObject.GetComponent<Text>();
        composantTexte.text = valeurDe.ToString();
        yourButton.interactable = false; // Désactive le bouton

    }

    public void lancerDe()
    {
        valeurDe = 31;
        yourButton.interactable = true;
    }

    public int getValeurDe()
    {
        return valeurDe;
    }
}






