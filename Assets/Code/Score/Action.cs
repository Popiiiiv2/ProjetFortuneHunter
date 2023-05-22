using UnityEngine;
using Cartes;

public class Action
{

    public void modifierArgent(ScoreJoueur score, CarteData carte)
    {
        switch (carte.getAction())
        {
            case "Perte":
                if (score.getMontant() < carte.getValeur())
                {
                    score.setMontant(0);
                }
                else
                {
                    score.setMontant(score.getMontant() - carte.getValeur());
                }
                break;
            case "Gain":
                score.setMontant(score.getMontant() + carte.getValeur());
                break;
            default: break;
        }
    }

    public void transfertArgentJoueur(ScoreJoueur donneur, ScoreJoueur receveur, int montant)
    {
        if (donneur.getMontant() >= montant)
        {
            donneur.setMontant(donneur.getMontant() - montant);
            receveur.setMontant(receveur.getMontant() + montant);
        }
        else
        {
            receveur.setMontant(receveur.getMontant() + donneur.getMontant());
            donneur.setMontant(0);
        }
    }

    public void verserPari(HudJoueur joueur, Cagnotte pari)
    {
        joueur.getScore().setMontant(joueur.getScore().getMontant() - 100);
        pari.setMontant(pari.getMontant() + 100);
    }

    public void participerPari(Cagnotte pari, bool[] valider, Joueur[] joueurs)
    {
        for (int i = 0; i < joueurs.Length; i++)
        {
            if (valider[i])
            {
                verserPari(joueurs[i].getHudJoueur(), pari);
            }
        }
    }

    public void transfertArgentCagnotte(ScoreJoueur donneur, Cagnotte cagnotte, CarteData carte)
    {
        int montant = carte.getValeur();
        if (donneur.getMontant() >= montant)
        {
            donneur.setMontant(donneur.getMontant() - montant);
            cagnotte.setMontant(cagnotte.getMontant() + montant);
        }
        else
        {
            cagnotte.setMontant(cagnotte.getMontant() + donneur.getMontant());
            donneur.setMontant(0);
        }

    }

    public void gagnerCagnotte(ScoreJoueur gagnant, Cagnotte cagnotte)
    {
        gagnant.setMontant(gagnant.getMontant() + cagnotte.getMontant());
        cagnotte.setMontant(0);
    }


    public void achat(ScoreJoueur acheteur, CarteData carte)
    {
        if (acheteur.estVide())
        {
            if (acheteur.getMontant() >= carte.getValeur())
            {
                acheteur.setMontant(acheteur.getMontant() - carte.getValeur());
                acheteur.setInventaire(carte);
            }
            else
            {
                Debug.Log("Pas assez d'argent");
            }
        }
        else
        {
            Debug.Log("Inventaire plein !");
        }
    }

    public void vente(ScoreJoueur vendeur)
    {
        if (!vendeur.estVide())
        {
            vendeur.setMontant(vendeur.getMontant() + vendeur.getInventaire().getVente());
            vendeur.viderInventaire();
        }
        else
        {
            Debug.Log("Ton inventaire est vide");
        }

    }

    public void actionCarte(ScoreJoueur score, Cagnotte cagnotte, CarteData carte)
    {
        switch (carte.getType())
        {
            case "Email":
                if (carte.getAction() == "Cagnotte")
                {
                    transfertArgentCagnotte(score, cagnotte, carte);
                }
                else
                {
                    modifierArgent(score, carte);
                }
                break;
            case "Event":
                if (carte.getAction() == "Cagnotte")
                {
                    transfertArgentCagnotte(score, cagnotte, carte);
                }
                else
                {
                    modifierArgent(score, carte);
                }
                break;
            case "Brocante":
                achat(score, carte);
                break;
            default: break;

        }

    }

}