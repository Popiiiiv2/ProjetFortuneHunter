using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonPig : MonoBehaviour
{
    private GameObject g;
    public Button monBouton;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        g = GameObject.Find("BackgroundCagnotte");
        monBouton.onClick.AddListener(afficherCacher);
    }

    void afficherCacher(){
        active = !active;
        g.SetActive(active);
    }
}
