using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //code pour gérer les scène du menu pour le bouton play pour lancer la game
    public void PlayGame() {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     SceneManager.LoadScene("CreationPartie");
    }
    
    public void QuitGame(){
        Application.Quit();

    }
}
