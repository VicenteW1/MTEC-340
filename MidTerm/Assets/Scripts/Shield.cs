using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    

    void Update()
    {
        if (spriteRenderer != null)
        {
            StartCoroutine(ShieldFlicker());
        }
    }

    IEnumerator ShieldFlicker()
    {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(6.0f);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        yield return new WaitForSeconds(2.0f);
        spriteRenderer.enabled = false;
    }

}
