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

    public SpriteRenderer spriteRenderer;

    AudioSource _source;
    GameObject shield;

    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (spriteRenderer != null)
        {
            StartCoroutine(ShieldFlicker());
        }
    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield() 
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }

    IEnumerator ShieldFlicker()
    {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(6.0f);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        yield return new WaitForSeconds(2.0f);
        DeactivateShield();
    }

    IEnumerator ShipDies()
    {
        spriteRenderer.enabled = false;
        Debug.Log("Launching destruction!");
        _source.PlayOneShot(_Explosion);
        Instantiate(explosionprefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            if (HasShield())
            {
                DeactivateShield();
            }
            else
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
                    StartCoroutine(ShipDies());
                }
            }


        }
       
        ShieldPowerUp powerUp = collision.GetComponent<ShieldPowerUp>();
        if (powerUp)
        {
            if (powerUp.activateShield)
            {
                ActivateShield();
            }
        }

    }
}
