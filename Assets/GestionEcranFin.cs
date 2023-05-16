using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GestionEcranFin : MonoBehaviour
{

    Text[] topNom;
    Text[] topArgent;
    Joueur[] joueurs;

    // Start is called before the first frame update
    void Start()
    {
        RecuperationDesVariables();
        topNom = new Text[joueurs.Length];
        topArgent = new Text[joueurs.Length];
        afficherFinPartie();
    }

    public void RecuperationDesVariables(){          
        GlobalVariable globalVars = FindObjectOfType<GlobalVariable>();
        joueurs = globalVars.GetJoueurs();
    }

    public void afficherFinPartie(){
        for(int i = 1; i <= topNom.Length; i++){
            string str = "topNom"+i;
            print(str);
            Text j = GameObject.Find(str).GetComponent<Text>();
            print(j);
            topNom[i-1] = j;
            str = "topScore"+i;
            j = GameObject.Find(str).GetComponent<Text>();
            topArgent[i-1] = j;
        }
        int x = joueurs.Length;
        for(int i = 0; i < x; i++){
            Joueur j = getMeilleurJoueur();
            topNom[i].text = j.getNomJoueur();
            topArgent[i].text = j.getArgent()+"€";
            supprimerJoueur(j);
        }
    }

    public Joueur getMeilleurJoueur(){
        Joueur joueurPlusRiche = joueurs[0];
        for (int i = 1; i < joueurs.Length; i++){
            if (joueurs[i].getArgent() > joueurPlusRiche.getArgent()) {
                joueurPlusRiche = joueurs[i];
            }
        }
        return joueurPlusRiche;
    }

    public void supprimerJoueur(Joueur j){
        if (Array.IndexOf(joueurs, j) != -1){
            Joueur[] nouveauTableau = new Joueur[joueurs.Length - 1];
            int indexJoueurASupprimer = Array.IndexOf(joueurs, j);

            Array.Copy(joueurs, 0, nouveauTableau, 0, indexJoueurASupprimer);
            Array.Copy(joueurs, indexJoueurASupprimer + 1, nouveauTableau, indexJoueurASupprimer, joueurs.Length - indexJoueurASupprimer - 1);

            joueurs = nouveauTableau;
        }
    }
}
