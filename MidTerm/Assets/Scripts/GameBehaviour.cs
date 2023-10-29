using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]


public class GameBehaviour : MonoBehaviour
{
    public int lives1 = 5;
    public int lives2 = 5;
    public Image[] lives1UI;
    public Image[] lives2UI;
    public GameObject explosionprefab;
    public GameObject explosion0prefab;
    [SerializeField] AudioClip _Explosion0;
    [SerializeField] AudioClip _Explosion;

    AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("projectile2"))
        {
            Instantiate(explosion0prefab, transform.position, Quaternion.identity);
            lives1 -= 1;
            for (int i = 0; i < lives1UI.Length; i++)
            {
                if (i < lives1)
                    lives1UI[i].enabled = true;
                else
                    lives1UI[i].enabled = false;

            }
            _source.PlayOneShot(_Explosion0);

            if (lives1 <= 0)
            {
                Debug.Log("Launching destruction!");
                _source.PlayOneShot(_Explosion);
                Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collision.gameObject);

            }
        }
        if (collision.gameObject.CompareTag("projectile1"))
        {
            Instantiate(explosion0prefab, transform.position, Quaternion.identity);
            lives2 -= 1;
            for (int i = 0; i < lives2UI.Length; i++)
            {
                if (i < lives2)
                    lives2UI[i].enabled = true;
                else
                    lives2UI[i].enabled = false;

            }
            _source.PlayOneShot(_Explosion0);

            if (lives2 <= 0)
            {
                Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                // ask why this doenst work here -> _source.PlayOneShot(_Explosion);
            }
        }
    }
}

