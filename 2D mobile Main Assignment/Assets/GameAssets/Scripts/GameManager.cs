using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameInMotion;
    public bool isBoardFull;

    private GameObject boardObject;

    private static GameManager instance;  //Singleton instance
    public static GameManager Instance { get { return instance; } }



    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        boardObject = GameObject.Find("BoardManager");
    }

    void Update()
    {
        CheckIfBoardFull();
    }

    private void CheckIfBoardFull()
    {
        if (boardObject.transform.childCount < 64)
        {
            isBoardFull = false;
        }
        else
        {
            isBoardFull = true;
        }
    }
}
