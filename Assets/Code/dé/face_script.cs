using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_script : MonoBehaviour
{
    cube_script script;
    void Awake() {
        script= GameObject.Find("dice").GetComponent<cube_script>();
    }
    void OnTriggerEnter (Collider other) {

        if(other.tag=="Piste"){
            script.face=int.Parse(gameObject.name);
        }
    }
}
