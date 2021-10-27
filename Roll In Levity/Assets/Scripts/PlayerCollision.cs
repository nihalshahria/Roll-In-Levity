using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gamemanager;
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacle"){
            Debug.Log(collisionInfo.collider.name);
            FindObjectOfType<Score>().OnDeath();
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }
}
