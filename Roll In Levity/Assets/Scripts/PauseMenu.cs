using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Player player;
    private bool GameIsPaused = false;

    public GameObject Pausemenu;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Pausemenu.SetActive(false);
        GameObject thePlayer = GameObject.Find("Player");
        Player player = thePlayer.GetComponent<Player>();
        player.velocity = 3;
        player.r = -360;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Pausemenu.SetActive(true);
        GameObject thePlayer = GameObject.Find("Player");
        Player player = thePlayer.GetComponent<Player>();
        player.velocity = 0;
        player.r = 0;
        GameIsPaused = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Menu", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
