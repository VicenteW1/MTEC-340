using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImerStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliiion");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player");
            if (!GameBehavior.Instance.timerRunning) GameBehavior.Instance.StartTimer();
            else GameBehavior.Instance.StopTimer();
            Destroy(this);
        }
    }
}
