using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau : MonoBehaviour
{
    public Case[] tabCase;
    private int TAILLE_MAX = 32;
    private static int NOMBRE_MAX_EVENEMENT = 11;
    private static int NOMBRE_MAX_PARI_SPORTIF = 1;
    private static int NOMBRE_MAX_BROCANTE = 6;
    private static int NOMBRE_MAX_MAIL = 8;
    private static int[] tab = {NOMBRE_MAX_BROCANTE, NOMBRE_MAX_PARI_SPORTIF, NOMBRE_MAX_EVENEMENT, NOMBRE_MAX_MAIL };


    public Case getCase(int numCase) {
        return tabCase[numCase];
    }

    public Case caseDebutPartie() {
		return tabCase[0];
	}

    public void setNumCase() {
        for(int i = 0; i < TAILLE_MAX; i++){
            tabCase[i].setNumCase(i);
        }
    }

    public void getAllCases(){
        for(int i = 0; i < TAILLE_MAX; i++){
            Debug.Log(tabCase[i].getNumCase());
        }
    }

    void Start()
    {
        setNumCase(); 
        setUpCases();
   }

   public static void enleverUn(int i){
        tab[i]--;
   }

    /*set-up pour les cases
    /!\/!\/!\ NE SURTOUT PAS LIRE CETTE FONCTION /!\/!\/!\
    */
    public void setUpCases(){
        TypeCase typeDernièreCase = TypeCase.DIMANCHE; 
        for(int i = 1; i < 31; i++){
            if(i%7 == 0){
                tabCase[i].setTypeCase(TypeCase.DIMANCHE);
                tabCase[i].GetComponent<Renderer>().material.color = TypeCaseExtensions.GetCouleur(TypeCase.DIMANCHE);
                typeDernièreCase = TypeCase.DIMANCHE;
            } else {
                TypeCase typeCase = TypeCaseExtensions.getRandomTypeCase(tab, typeDernièreCase);
                tabCase[i].setTypeCase(typeCase);
                tabCase[i].GetComponent<Renderer>().material.color = TypeCaseExtensions.GetCouleur(typeCase);
                typeDernièreCase = typeCase;
            }
        }
        tabCase[31].setTypeCase(TypeCase.PAYE);
        tabCase[31].GetComponent<Renderer>().material.color = TypeCaseExtensions.GetCouleur(TypeCase.PAYE);
    }
}
