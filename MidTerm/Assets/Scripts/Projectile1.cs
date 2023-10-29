using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float YLimit = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;

        if (transform.position.y >= YLimit)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ship2"))
        {
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("projectile2"))
        {
            Destroy(gameObject);
        }
    }

}
