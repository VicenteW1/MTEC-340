using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipBehaviour : MonoBehaviour
{
    public float XLimit = 5.80f;
    public float ShipSpeed = 8.0f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;


    public GameObject explosionprefab;
    public GameObject explosion0prefab;
    [SerializeField] AudioClip _Explosion0;
    [SerializeField] AudioClip _Explosion;

    AudioSource _source;

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

    }

    public void DestroyShip()
    {
        Destroy(gameObject);
    }

} 
