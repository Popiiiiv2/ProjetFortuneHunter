using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau
{

    private Case[] cases;
    private static int TAILLE = 32;


    public Plateau() {
        cases = new Case[TAILLE];
        for(int i = 0; i < TAILLE; i++){
            cases[i] = new Case(i);
        }
    }

    public Case getCase(int numCase) {
        return cases[numCase];
    }

    public Case caseDebutPartie() {
		return cases[0];
	}

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
