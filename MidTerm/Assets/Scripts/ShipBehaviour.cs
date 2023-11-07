using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public float XLimit = 5.80f;
    public float ShipSpeed = 8.0f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;
    public KeyCode dash;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f; 

    private float dashCounter;
    private float dashCoolCounter;

    

    void Start()
    {
        activeMoveSpeed = ShipSpeed;
    }

    void Update()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.State.Play)
        {
            if (Input.GetKey(RightDirection) && transform.position.x < XLimit)
            {
                transform.position += new Vector3(activeMoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(LeftDirection) && transform.position.x > -XLimit)
            {
                transform.position -= new Vector3(activeMoveSpeed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKeyDown(dash))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }
            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <= 0)
                {
                    activeMoveSpeed = ShipSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }

            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }

    }



} 
