using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCreation : MonoBehaviour
{
    
    //code pour gérer les scène du menu pour le bouton play pour lancer la game
    public void PlayGame() {
     SceneManager.LoadScene("Plateau");
    }
    
    public void QuitGame(){
        Debug.Log("QUIT");
        Application.Quit();

    }
}
