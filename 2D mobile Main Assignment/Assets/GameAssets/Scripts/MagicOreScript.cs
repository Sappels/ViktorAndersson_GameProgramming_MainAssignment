using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{
    private GameObject playerHandler;
    private Player player;

    private GameObject boardHandler;
    private Board board;

    public Vector2 boardPosition;
    public Vector2 swapPosition;

    private bool swapIndex;
    
    public int columnIndex, rowIndex;
    
    private void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("PlayerHandler");
        boardHandler = GameObject.FindGameObjectWithTag("BoardHandler");
        player = playerHandler.GetComponent<Player>();
        board = boardHandler.GetComponent<Board>();

        //boardPosition = transform.position;
        //swapPosition = boardPosition;
    }

    private void Update()
    {
        if (swapIndex)
        {

        }
    }

    private void OnMouseEnter()
    {
        if (player.currentOre == null)
        {
            player.currentOre = gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MagicOre"))
        {
            swapIndex = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("MagicOre"))
        {
            swapIndex = true;
        }
    }

}
