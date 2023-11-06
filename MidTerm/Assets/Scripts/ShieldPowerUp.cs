using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float moveSpeed;
    public bool activateShield;

    private bool hasSpawned = false;

  private void FixedUpdate()
    {
       /* if (!hasSpawned)
        {
            hasSpawned = true;
            SpawnRandomly();
        }
       */
        MovePowerUp();
    }
  /*
    private void SpawnRandomly()
    {
        float randomY = Random.Range(-5f, 10f); // Generate random y-coordinate between -5 and 10
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        transform.position = spawnPosition;
    }
    */
    private void MovePowerUp()
    {
        Vector3 pos = transform.position;
        pos.y -= moveSpeed * Time.fixedDeltaTime;

        if (pos.y > 10 || pos.y < -10)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}