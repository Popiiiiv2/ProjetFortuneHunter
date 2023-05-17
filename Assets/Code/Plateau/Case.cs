using UnityEngine;

public class Case : MonoBehaviour
{
    private TypeCase typeCase;
    private int numCase;

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
