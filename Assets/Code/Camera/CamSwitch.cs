using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject camPlateau;
    public GameObject camDe;
    public bool surCameraPlateau;
    // Start is called before the first frame update

    public void cameraPlateau(){
        camPlateau.SetActive(true);
        camDe.SetActive(false);
    }

    public void cameraDe(){
        camPlateau.SetActive(false);
        camDe.SetActive(true);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            camPlateau.SetActive(true);
            camDe.SetActive(false);
        } 
        if(Input.GetKeyDown(KeyCode.R)){
            camPlateau.SetActive(false);
            camDe.SetActive(true);
        }
    }
}
