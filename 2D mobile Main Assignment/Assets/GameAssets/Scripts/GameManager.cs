using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameInMotion;

    private Board board;
    private Player player;
    private OreDropper oreDropper;

    void Start()
    {
        board = GameObject.Find("BoardManager").GetComponent<Board>();
        player = GameObject.Find("PlayerHandler").GetComponent<Player>();
        oreDropper = GameObject.Find("OreDropper").GetComponent<OreDropper>();
    }

    void Update()
    {

    }
}
