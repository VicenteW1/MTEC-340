using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    //properties
    int _score;
    public int Score
    {
        get => _score;

        set  
        {
            _score = value;
            _scoreGui.text = Score.ToString();
        }
    }

    [SerializeField] TextMeshProUGUI _scoreGui;
}