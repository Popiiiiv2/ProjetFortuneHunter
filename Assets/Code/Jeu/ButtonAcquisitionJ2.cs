using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAcquisitionJ2 : MonoBehaviour
{
    private GameObject g;
    public Button monBouton;
    private bool active;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        g = GameObject.Find("Back_acquiJ2");
        initialPosition = g.transform.position;
        monBouton.onClick.AddListener(afficherCacher);
    }

   void afficherCacher()
    {
        active = !active;

        // Changer la position sur l'axe X
        Vector3 newPosition = initialPosition;
        if (active)
        {
            newPosition.y = 5500;
        }
        else
        {
            newPosition.y = 700;
        }

        // Appliquer la nouvelle position à l'objet
        g.transform.position = newPosition;
    }
}
