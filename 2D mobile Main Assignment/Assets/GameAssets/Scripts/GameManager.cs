using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject boardObject;

    private float localTimer = 2f;
    
    public bool gameInMotion;
    public bool isBoardFull;
    public bool allowGravity;

    public float gameSpeed;

    private static GameManager instance;
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
        SetGameInMotion();
        CheckIfBoardFull();
    }

    private void SetGameInMotion()
    {
        if (localTimer > -0.1)
            localTimer -= Time.deltaTime;

        if (localTimer <= 0)
        {
            gameInMotion = true;
        }
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
