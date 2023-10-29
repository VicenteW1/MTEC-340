using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public int dayofBirth = 12; 
    public string monthofBirth = "March"; 

    void Start()

    {   
        Debug.Log($"I was born the {dayofBirth} of {monthofBirth}");    
    }

}
