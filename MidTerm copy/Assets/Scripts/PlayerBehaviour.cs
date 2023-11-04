using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _lives;
    public int Lives
    {
        get => _lives;
        set
        {
            _lives = value;
            for (int i = 0; i < Lives; i++)
            {
                if (i < Lives)
                    livesUI[i].enabled = true;
                else
                    livesUI[i].enabled = false;
            }
           
        }
    }

    [SerializeField] Image[] livesUI;

}