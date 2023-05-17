using UnityEngine;

public class Plateau : MonoBehaviour
{
    private Case[] tabCase;
    private int TAILLE_MAX = 32;
    private static int NOMBRE_MAX_EVENEMENT = 11;
    private static int NOMBRE_MAX_PARI_SPORTIF = 1;
    private static int NOMBRE_MAX_BROCANTE = 6;
    private static int NOMBRE_MAX_MAIL = 8;
    private static int[] tab = {NOMBRE_MAX_BROCANTE, NOMBRE_MAX_PARI_SPORTIF, NOMBRE_MAX_EVENEMENT, NOMBRE_MAX_MAIL };

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
        creerCases();
        setNumCase(); 
        setUpCases();
   }

   public void creerCases(){
        tabCase = new Case[TAILLE_MAX];
        for(int i = 0; i < TAILLE_MAX; i++){
            string str = "Case" + i;
            tabCase[i] = GameObject.Find(str).GetComponent<Case>();
        } 
   }

   public static void enleverUn(int i){
        tab[i]--;
   }

    //set-up pour les cases
    public void setUpCases(){
        TypeCase typeDernièreCase = TypeCase.DIMANCHE;
        for (int i = 1; i < TAILLE_MAX-1; i++) {
        if (i % 7 == 0) {
            setTypeAndColor(tabCase[i], TypeCase.DIMANCHE);
            typeDernièreCase = TypeCase.DIMANCHE;
        } else {
            TypeCase typeCase = TypeCaseExtensions.getRandomTypeCase(tab, typeDernièreCase);
            setTypeAndColor(tabCase[i], typeCase);
            typeDernièreCase = typeCase;
        }
        setTypeAndColor(tabCase[31], TypeCase.PAYE);
        }
    }

    private void setTypeAndColor(Case cas, TypeCase typeCase) {
        cas.setTypeCase(typeCase);
        cas.GetComponent<Renderer>().material.color = TypeCaseExtensions.GetCouleur(typeCase);
    }

    public Case[] getCases(){
        return tabCase;
    }
}
