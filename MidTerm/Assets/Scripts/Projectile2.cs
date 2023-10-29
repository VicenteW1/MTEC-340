using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float YLimit = 5.0f;


    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, moveSpeed, 0) * Time.deltaTime;

        if (transform.position.y <= -YLimit)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ship1"))
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("projectile1"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}

