//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]


//public class GameBehaviour : MonoBehaviour
//{
//    public static GameBehaviour Instance;

//    [SerializeField] Player[] Players = new Player[2];
//    public GameObject explosionprefab;
//    public GameObject explosion0prefab;
//    [SerializeField] AudioClip _Explosion0;
//    [SerializeField] AudioClip _Explosion;

//    public int numberLivesloose = 0;

//    AudioSource _source;

//    private void Awake()
//    {
//        if (Instance != null && Instance != this)
//        {
//            Destroy(this);
//        }
//        else
//        {
//            Instance = this;
//        }
//    }
//    void Start()
//    {
//        _source = GetComponent<AudioSource>();
//    }

//    void Update()
//    {

//    }

//    public void UpdateScore(int player)
//    {
//        Players[player - 1].Lives--;
//        //CheckWinner();
//    }

//    //private void CheckWinner()
//    //{
//    //    if (Players[0].Lives >= numberLivesloose || Players[1].Lives >= numberLivesloose)
//    //    {
//    //        string winnerMessage = $"Player {(Players[0].Lives > Players[1].Live ? 1 : 2)} wins"!;
//    //        _winnerMessage.text = winnerMessage;
//    //        _winnerMessage.enabled = true;
//    //        GuiManager.Instance.UpdateMessageGUI(_gameOverMessage);
//    //    }


//    //}

//}

