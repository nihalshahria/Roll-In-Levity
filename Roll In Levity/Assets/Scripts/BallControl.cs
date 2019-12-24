using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private float move;
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
    }
}
