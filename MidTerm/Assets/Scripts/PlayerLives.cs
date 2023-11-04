using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]


public class PlayerLives : MonoBehaviour
{
    public int lives = 5;
    public Image[] livesUI;
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
        if (collision.gameObject.CompareTag("projectile"))
        {
            Instantiate(explosion0prefab, transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                    livesUI[i].enabled = true;
                else
                    livesUI[i].enabled = false;

            }
            _source.PlayOneShot(_Explosion0);

            if (lives <= 0)
            {
                Debug.Log("Launching destruction!");
                _source.PlayOneShot(_Explosion);
                Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collision.gameObject);

            }


        }


    }
}
