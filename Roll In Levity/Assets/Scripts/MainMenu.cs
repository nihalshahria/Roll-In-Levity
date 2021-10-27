using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScore;
    private void Start(){
        HighScore.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }
    public void PlayGame(int sceneIndex){
        sceneIndex = 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
