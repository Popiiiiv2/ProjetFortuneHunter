using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationPartie : MonoBehaviour
{
    public Dropdown ddMois;
    private string nbMois;

    public Dropdown ddJoueur;
    private string nbJoueur;
    public GameObject input3;
    public GameObject input4;
    public InputField legacyInputField1;
    public InputField legacyInputField2;
    public InputField legacyInputField3;
    public InputField legacyInputField4;

    private GlobalVariable globalVars;

    void Update()
    {
        //Recuper la valeur de nombre de mois choisi par les joueurs
        nbMois = ddMois.captionText.text;
        globalVars.setNbMois(nbMois);

        //Recuper la valeur de nombre de joueurs choisi par les joueurs
        nbJoueur = ddJoueur.captionText.text;
        globalVars.setNbJoueur(nbJoueur);
        Debug.Log(globalVars.getNbJoueur());

        switch (nbJoueur)
        {
            case "2":
                if (input3.activeInHierarchy == true || input4.activeInHierarchy == true)
                {
                    input3.SetActive(false);
                    input4.SetActive(false);
                }
                globalVars.setNomJoueur(0, legacyInputField1.text);
                globalVars.setNomJoueur(1, legacyInputField2.text);
                break;
            case "3":
                input3.SetActive(true);
                if (input4.activeInHierarchy == true)
                {
                    input4.SetActive(false);
                }
                globalVars.setNomJoueur(0, legacyInputField1.text);
                globalVars.setNomJoueur(1, legacyInputField2.text);
                globalVars.setNomJoueur(2, legacyInputField3.text);
                Debug.Log(globalVars.getNomJoueur(2));
                break;
            case "4":
                input3.SetActive(true);
                input4.SetActive(true);
                globalVars.setNomJoueur(0, legacyInputField1.text);
                globalVars.setNomJoueur(1, legacyInputField2.text);
                globalVars.setNomJoueur(2, legacyInputField3.text);
                globalVars.setNomJoueur(3, legacyInputField4.text);
                break;
        }
    }

    private void Start()
    {
        globalVars = FindObjectOfType<GlobalVariable>();
    }
}
