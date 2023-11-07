using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GuiManager : MonoBehaviour
{
    public static GuiManager Instance;
    [SerializeField] TextMeshProUGUI _messageSSB;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void TogggleGUIVisibility(TextMeshProUGUI textSSB)
    {
        textSSB.enabled = !textSSB.enabled;
    }

    public void UpdateMessageGUI(TextMeshProUGUI textupdate)
    {
        TogggleGUIVisibility(textupdate);
    }
}
