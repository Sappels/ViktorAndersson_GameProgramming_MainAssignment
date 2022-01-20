using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [SerializeField] int columnLength;
    [SerializeField] int rowHeight;
    [SerializeField] float spacing;
    [SerializeField] GameObject[] magicOres;
    [SerializeField] List<GameObject> magicOresToSpawn = new List<GameObject>();

    //Sliders I might need for both players health and mana
    //public Slider player1SpellMeter;
    //public Slider player2SpellMeter;
 
    //public Slider player1HealthBar;
    //public Slider player2HealthBar;

    [SerializeField] private GameObject magicOre;
    public GameObject[,] boardArray;

    private int randomOre;

    //I do not care about these bools for now they are just here so the if statements make some more sense
    private bool playerMakesMove;
    private bool match3;
    private bool outOfMoves;
    private bool combined;

    void Start()
    {
        CreateBoard();
    }

    void Update()
    {
        if (playerMakesMove)
        {
            CombinationChecker();
            if (match3)
            {
                BreakOre();
            }
        }

        if (outOfMoves)
        {
            EndTurn();
        }
    }

    private void CreateBoard()
    {
        boardArray = new GameObject[columnLength, rowHeight];

        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowHeight; j++)
            {
                MagicOreRandomizer();
                boardArray[i, j] = (GameObject)Instantiate(magicOre, new Vector3(i, j, 0) / spacing, Quaternion.identity, transform);
            }
        }

        transform.position = new Vector3((-(float)(columnLength - 1) / spacing) / 2, -((float)(rowHeight - 1) / spacing) / 2 - 3.5f, 0);
    }

    private void CombinationChecker()
    {
        if (combined)
        {
            //Save arrayposition of aligned ores
            //Call function for breaking ores
        }
        throw new NotImplementedException();
    }

    private void BreakOre()
    {
        //Take mana value, add to manapot
        //Add +1 to ores broken
        //foreach broken ore, MagicOreRandomizer();
        OreDropper();
        throw new NotImplementedException();
    }

    private void OreDropper()
    {
        //Hämta rowHeight på förstörda ores från CombinationChecker()
        //Gå -- till du når toppen, spara alla obj, ta deras position och ++
        //Kolla om det finns tomma slots på toppraden, kör NewOreSpawner();
        throw new NotImplementedException();
    }

    private void MagicOreRandomizer()
    {
        randomOre = Random.Range(0, 6);
        magicOre = magicOres[randomOre];
        //Lägg till random ore i MagicOresToSpawn;
    }

    private void NewOreSpawner()
    {
        //Ta ore från MagicOresToSpawn till boardArray och lägg dom i dom tomma slotsen
        throw new NotImplementedException();
    }

    private void EndTurn()
    {
        //Add collected mana to spell meter
        NewTurn();
        throw new NotImplementedException();
    }

    private void NewTurn()
    {
        //movesLeft reset
        //switch player
        throw new NotImplementedException();
    }
}
