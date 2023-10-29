using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float YLimit = 4.0f;

    public KeyCode UpDirection;
    public KeyCode DownDirection;


    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.GameStates.Play)
        {
            if (Input.GetKey(UpDirection) && transform.position.y < YLimit)
            {
                transform.position += new Vector3(0, GameBehavior.Instance.PaddleSpeed, 0) * Time.deltaTime;
            }

            else if (Input.GetKey(DownDirection) && transform.position.y > -YLimit)
            {
                transform.position -= new Vector3(0, GameBehavior.Instance.PaddleSpeed, 0) * Time.deltaTime;
            }
        }
     
    }
}
