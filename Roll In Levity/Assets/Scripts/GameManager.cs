using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamehasEnded = false;
    public GameObject GameOver;
    public Player player;
   public void EndGame()
    {
        if(gamehasEnded == false)
        {
            gamehasEnded = true;
            Debug.Log("GAME OVER");
            GameObject thePlayer = GameObject.Find("Player");
            Player player = thePlayer.GetComponent<Player>();
            player.velocity = 0;
            GameOver.SetActive(true);
        }
        
    }
    /*void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
