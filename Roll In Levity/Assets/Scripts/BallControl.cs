using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private float move;
    public GameObject Pausemenu;
    public Player player;
    private void Update()
    {
        if (Input.GetKey("d"))
        {
            move = 1;
        }
        else if (Input.GetKey("a"))
        {
            move = -1;
        }
        else
        {
            move = 0;
        }
        transform.Rotate(new Vector3(85*move, 0, 0) * 2 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausemenu.SetActive(true);
            GameObject thePlayer = GameObject.Find("Player");
            Player player = thePlayer.GetComponent<Player>();
            player.velocity = 0;
            //GameIsPaused = true;
        }
    }
}
