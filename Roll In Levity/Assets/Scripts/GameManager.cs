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
            //Destroy(Ball.gameObject);
            Debug.Log("GAME OVER");
            //FindObjectOfType<Player>().velocityChange();
            GameObject thePlayer = GameObject.Find("Player");
            Player player = thePlayer.GetComponent<Player>();
            player.velocity = 0;
            /*GameObject score = GameObject.Find("Score");
            Score scoretext = score.GetComponent<Score>();
            score.scoretext = scoretext;*/
            GameOver.SetActive(true);
            //Restart();
        }
        
    }
    /*void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
