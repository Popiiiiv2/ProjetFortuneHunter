using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau : MonoBehaviour
{
    public Case[] tabCase;
    private int TAILLE_MAX = 32;

    public Case getCase(int numCase)
    {
        return tabCase[numCase];
    }

    public Case caseDebutPartie()
    {
        return tabCase[0];
    }

    public void setNumCase()
    {
        for (int i = 0; i < TAILLE_MAX; i++)
        {
            tabCase[i].setNumCase(i);
        }
    }

    public void getAllCases()
    {
        for (int i = 0; i < TAILLE_MAX; i++)
        {
            Debug.Log(tabCase[i].getNumCase());
        }
    }

    void Start()
    {
        setNumCase();
    }
}
