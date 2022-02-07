using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameInMotion;
    public bool isBoardFull;

    private Board board;
    private Player player;
    private OreDropper oreDropper;

    private GameObject boardObject;

    void Start()
    {
        board = GameObject.Find("BoardManager").GetComponent<Board>();
        boardObject = GameObject.Find("BoardManager");
        player = GameObject.Find("PlayerHandler").GetComponent<Player>();
        oreDropper = GameObject.Find("OreDropper").GetComponent<OreDropper>();
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
