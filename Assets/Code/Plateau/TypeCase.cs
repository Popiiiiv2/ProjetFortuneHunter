using System.Collections.Generic;
using UnityEngine;

public enum TypeCase
{
    BROCANTE,
    PARI_SPORTIF,
    EVENEMENT,
    MAIL,
    PAYE,
    DIMANCHE
}

public static class TypeCaseExtensions
{
    public static Color GetCouleur(TypeCase type)
    {
        switch (type)
        {
            case TypeCase.BROCANTE:
                return Color.magenta;
            case TypeCase.PARI_SPORTIF:
                return Color.blue;
            case TypeCase.EVENEMENT:
                return Color.green;
            case TypeCase.DIMANCHE:
                return Color.gray;
            case TypeCase.MAIL:
                return Color.black;
            case TypeCase.PAYE:
                return Color.red;
            default:
                return Color.white; ;
        }
    }

    public static TypeCase getRandomTypeCase(int[] tab, TypeCase typeDernièreCase)
    {
        int[] tabInt = caseDisponible(tab, typeDernièreCase);
        int x = NombreAleatoireNonContinu(tabInt);
        switch (x)
        {
            case 1:
                Plateau.enleverUn(0);
                return TypeCase.BROCANTE;
            case 2:
                Plateau.enleverUn(1);
                return TypeCase.PARI_SPORTIF;
            case 3:
                Plateau.enleverUn(2);
                return TypeCase.EVENEMENT;
            case 4:
                Plateau.enleverUn(3);
                return TypeCase.MAIL;
            default:
                return TypeCase.EVENEMENT;
        }
    }

    public static int NombreAleatoireNonContinu(int[] valeurs)
    {
        int index = Random.Range(0, valeurs.Length);
        return valeurs[index];
    }

    public static int[] caseDisponible(int[] tab, TypeCase typeDernièreCase)
    {
        List<int> list = new List<int>();

        if (tab[0] != 0 && typeDernièreCase != TypeCase.BROCANTE)
        {
            list.Add(1);
        }
        if (tab[1] != 0 && typeDernièreCase != TypeCase.PARI_SPORTIF)
        {
            list.Add(2);
        }
        if (tab[2] != 0 && typeDernièreCase != TypeCase.EVENEMENT)
        {
            list.Add(3);
        }
        if (tab[3] != 0 && typeDernièreCase != TypeCase.MAIL)
        {
            list.Add(4);
        }

        if (list.Count == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tab[i] != 0)
                {
                    list.Add(i + 1);
                }
            }
        }
        
        return list.ToArray();
    }
}
