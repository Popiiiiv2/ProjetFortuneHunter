using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public Plateau plateau;
    private TypeCase typeCase;
    private int numCase;

    private string type;

    public Case(string type)
    {
        this.type = type;
    }
    public void setNumCase(int numCase)
    {
        this.numCase = numCase;
    }

    public int getNumCase()
    {
        return numCase;
    }

    public void setTypeCase(TypeCase typeCase)
    {
        this.typeCase = typeCase;
    }

    public TypeCase getTypeCase()
    {
        return typeCase;
    }
}
