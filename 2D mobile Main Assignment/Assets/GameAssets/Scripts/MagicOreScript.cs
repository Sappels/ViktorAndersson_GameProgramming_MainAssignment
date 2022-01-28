using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{
    private GameObject playerHandler;
    private Player player;

    private GameObject boardHandler;
    private Board board;

    private int mana = 100;
    
    public bool pickedUp;
    
    public int columnIndex, rowIndex;
    public Vector2 boardPosition;

    
    private void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("PlayerHandler");
        boardHandler = GameObject.FindGameObjectWithTag("BoardHandler");
        player = playerHandler.GetComponent<Player>();
        board = boardHandler.GetComponent<Board>();
        boardPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!pickedUp)
        {
            transform.localPosition = boardPosition;
        }
    }

    public int GetMana()
    {
        return mana;
    }

}
