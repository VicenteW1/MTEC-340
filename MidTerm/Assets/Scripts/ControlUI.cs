using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _topShip;
    [SerializeField] TextMeshProUGUI _bottomShip;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _topShip.enabled = !_topShip.enabled;
            _bottomShip.enabled = !_bottomShip.enabled;


        }
    }
}
