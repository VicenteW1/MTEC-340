using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public GameObject projectilePrefab;

    public KeyCode Shoot;

    public bool readyToShoot = true;

    public Transform FirePoint;

    private void Start()
    {
        StartCoroutine(WaitBetweenShots());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Shoot) && readyToShoot == true)
        {
            Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
            readyToShoot = false;
           
        }
    }


    IEnumerator WaitBetweenShots()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); //Insert your desired wait in the brackets

            readyToShoot = true;
        }
    }



}
