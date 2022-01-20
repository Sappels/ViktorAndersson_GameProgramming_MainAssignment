using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{
    private GameObject playerHandler;
    private Player player;

    private GameObject boardHandler;
    private Board board;

    private int indexLength;
    private int lengthPos, heightPos;

    private void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("PlayerHandler");
        boardHandler = GameObject.FindGameObjectWithTag("BoardHandler");
        player = playerHandler.GetComponent<Player>();
        board = boardHandler.GetComponent<Board>();
    }
    private void Update()
    {
        //index = System.Array.IndexOf(board.boardArray, gameObject);
        //indexLength = board.boardArray[,gameObject];
    }
    
    private void OnMouseEnter()
    {
        player.currentOre = gameObject;
    }
    
    private void OnMouseExit()
    {
        player.currentOre = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MagicOre"))
        {
            //swap slots
        }
    }
}
