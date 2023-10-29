using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public float XLimit = 5.80f;
    public float ShipSpeed = 8.0f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;
    //public KeyCode dash;

    //private bool canDash;
    //private bool isDashing;
    //[SerializeField] float dashingPower = 24f;
    //[SerializeField] float dashingTime = 0.2f;
    //[SerializeField] float dashingCooldown = 3.0f;

    //[SerializeField] TrailRenderer tr;



    void Update()
    {
        if (Input.GetKey(RightDirection) && transform.position.x < XLimit)
        {
            transform.position += new Vector3(ShipSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(LeftDirection) && transform.position.x > -XLimit)
        {
            transform.position -= new Vector3(ShipSpeed, 0, 0) * Time.deltaTime;
        }

        //if (Input.GetKeyDown(dash))
        //{
        //    StartCoroutine(Dash());
        //}
    }

    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    new Vector2(transform.localScale.x * dashingPower, 0f);
    //    tr.emitting = true;
    //    yield return new WaitForSeconds(dashingTime);
    //    tr.emitting = false;
    //    isDashing = false;
    //    yield return new WaitForSeconds(dashingCooldown);
    //}
} 
