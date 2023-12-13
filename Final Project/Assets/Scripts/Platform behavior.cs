using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformbehavior : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 3.0f;  

    void Start()
    {
        StartCoroutine(MoveBetweenPoints());
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            yield return MoveTo(pointB.position);
            yield return MoveTo(pointA.position);
        }
    }

    IEnumerator MoveTo(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}



