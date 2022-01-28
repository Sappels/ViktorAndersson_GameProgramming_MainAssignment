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
    [SerializeField] GameObject magicOre;
    [SerializeField] GameObject[] magicOres;
    [SerializeField] List<GameObject> magicOresToSpawn = new List<GameObject>();

    public GameObject[,] boardArray;

    private int randomOre;

    //I do not care about these bools for now they are just here so the if statements make some more sense
    private bool playerMakesMove;
    private bool match3;
    private bool outOfMoves;
    private bool combined;

    void Start()
    {
        Application.targetFrameRate = 60;
        FillOrePool();
        CreateBoard();
    }

    void Update()
    {
        UpdateBoard();

        foreach (GameObject item in magicOresToSpawn)
        {
            item.SetActive(false);
        }
    }

    private void UpdateBoard()
    {
        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowHeight; j++)
            {
                    boardArray[i, j].GetComponent<MagicOreScript>().boardPosition = new Vector2(i, j) * spacing;

                    boardArray[i, j].GetComponent<MagicOreScript>().columnIndex = i;
                    boardArray[i, j].GetComponent<MagicOreScript>().rowIndex = j;
            }
        }
    }

    private void CreateBoard()
    {
        boardArray = new GameObject[columnLength, rowHeight];

        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowHeight; j++)
            {

                int _randomOre = Random.Range(0,magicOresToSpawn.Count);

                boardArray[i, j] = magicOresToSpawn[_randomOre];
                boardArray[i, j].SetActive(true);
                boardArray[i, j].transform.position = new Vector3(i, j, 0) * spacing;
                boardArray[i, j].transform.rotation = Quaternion.identity;
                boardArray[i, j].transform.parent = transform;

                boardArray[i,j].GetComponent<MagicOreScript>().columnIndex = i;
                boardArray[i,j].GetComponent<MagicOreScript>().rowIndex = j;

                magicOresToSpawn.RemoveAt(_randomOre);
            }
        }
    }

    private void FillOrePool()
    {
        foreach (GameObject item in magicOres)
        {
            for (int i = 0; i < 19; i++)
            {
                magicOresToSpawn.Add(Instantiate(item));
                //item.SetActive(false);
            }
        }
    }

    private void CombinationChecker()
    {

        //Save arrayposition of aligned ores
        //Call function for breaking ores
        throw new NotImplementedException();
    }

    public void BreakOre(GameObject ore)
    {
        int _i = ore.GetComponent<MagicOreScript>().columnIndex;
        int _j = ore.GetComponent<MagicOreScript>().rowIndex;

        int _randomOre = Random.Range(0, magicOresToSpawn.Count);

        ore.SetActive(false);
        magicOresToSpawn.Add(ore);
        //boardArray[_i, _j] = null;

        for (int j = _j - 1; j < rowHeight; j++)
        {
            boardArray[_i, j] = boardArray[_i, j--];
        }

        ore = magicOresToSpawn[_randomOre];

        boardArray[_i, _j] = ore;

        //OreDropper(ore);
        throw new NotImplementedException();
    }

    private void OreDropper(GameObject ore)
    {



        //for (int i = 0; i < columnLength; i++)
        //{
        //    int _randomOre = Random.Range(0, magicOresToSpawn.Count);
        //
        //    if (boardArray[i, 7] = null)
        //    {
        //        boardArray[i, 7] = magicOresToSpawn[_randomOre];
        //        boardArray[i, 7].SetActive(true);
        //        boardArray[i, 7].transform.parent = transform;
        //
        //        magicOresToSpawn.Remove(boardArray[i, 7]);
        //    }
        //}
        throw new NotImplementedException();
    }

    private void MagicOreRandomizer()
    {
        randomOre = Random.Range(0, 7);
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
