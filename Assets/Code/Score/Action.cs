using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartes;

public class Action : MonoBehaviour
{

    public void modifierArgent(ScoreJoueur score, CarteData carte) {
        switch (carte.getAction()) {
            case "Perte" : 
                score.setMontant(score.getMontant() - carte.getValeur());
                break;
            case "Gain" : 
                score.setMontant(score.getMontant() + carte.getValeur());
                break;
            default: break;
        }
    }

    public void transfertArgentJoueur(ScoreJoueur donneur, ScoreJoueur receveur, int montant) {
        if (donneur.getMontant() >= montant) {
            donneur.setMontant(donneur.getMontant() - montant);
            receveur.setMontant(receveur.getMontant() + montant);
        } else {
            receveur.setMontant(receveur.getMontant() + donneur.getMontant());
            donneur.setMontant(0);
        }
    }

    public void transfertArgentCagnotte(ScoreJoueur donneur, Cagnotte cagnotte, int montant) {
        if (donneur.getMontant() >= montant) {
            donneur.setMontant(donneur.getMontant() - montant);
            cagnotte.setMontant(cagnotte.getMontant() + montant);
        } else {
            cagnotte.setMontant(cagnotte.getMontant() + donneur.getMontant());
            donneur.setMontant(0);
        }
        
    }

    public void gagnerCagnotte(ScoreJoueur gagnant, Cagnotte cagnotte) {
        gagnant.setMontant(gagnant.getMontant() + cagnotte.getMontant());
        cagnotte.setMontant(0);
    }
/*
    public void participerPari() {

    }

    public void gagnerPari() {

    }

    public bool choixAchatVente() {
        return ;
    }

*/
    public void achat(ScoreJoueur acheteur, CarteData carte) {
        if (acheteur.getMontant() >= carte.getValeur()) {
            acheteur.setMontant(acheteur.getMontant() - carte.getValeur());
            acheteur.getInventaire().Add(carte);
        } else {
            Debug.Log("Pas assez d'argent");
        }
    }

    public void vente(ScoreJoueur vendeur) {
        if (vendeur.getInventaire().Count > 0) {
            // Demander à l'utilisateur quelle carte il veut vendre
            int index = 0;
            vendeur.setMontant(vendeur.getMontant() + vendeur.getInventaire()[index].getVente());
            vendeur.getInventaire().RemoveAt(index);
        } else {
            Debug.Log("Ton inventaire est vide");
        }

    }

}
