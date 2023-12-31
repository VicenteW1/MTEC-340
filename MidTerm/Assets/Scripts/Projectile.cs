using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float YLimit;

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Projectile");
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= YLimit || transform.position.y <= -YLimit)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ship"))
        {
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("projectile"))
        {
            Destroy(gameObject);
        }

    }
}

