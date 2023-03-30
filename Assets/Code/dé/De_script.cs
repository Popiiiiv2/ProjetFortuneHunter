using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class De_script : MonoBehaviour
{
    De de;
    void Awake() {
        de= GameObject.Find("dice").GetComponent<De>();
    }
    void OnTriggerEnter (Collider other) {

        if(other.tag=="Piste"){
            de.face=int.Parse(gameObject.name);
        }
    }
}
