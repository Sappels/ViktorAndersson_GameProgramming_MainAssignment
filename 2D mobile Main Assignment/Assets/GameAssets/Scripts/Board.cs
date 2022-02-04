using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    List<GameObject> oresOnBoard = new List<GameObject>();
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

                //GameObject ore = magicOresToSpawn[_randomOre];
                //
                //oresOnBoard.Add(ore);
                //ore.transform.parent = transform;
                //ore.transform.position = new Vector3(i, j, 0) * spacing;
                //ore.transform.rotation = Quaternion.identity;
                //magicOresToSpawn.RemoveAt(_randomOre);
                //ore.SetActive(true);
                boardArray[i, j] = magicOresToSpawn[_randomOre];
                boardArray[i, j].SetActive(true);
                boardArray[i, j].transform.position = new Vector3(i, j, 0) * spacing;
                boardArray[i, j].transform.rotation = Quaternion.identity;
                boardArray[i, j].transform.parent = transform;
                magicOresToSpawn.RemoveAt(_randomOre);

                
                boardArray[i,j].GetComponent<MagicOreScript>().columnIndex = i;
                boardArray[i,j].GetComponent<MagicOreScript>().rowIndex = j;
                HideOrePoolAtStart();
            }
        }
    }

    private void HideOrePoolAtStart()
    {
        foreach (GameObject item in magicOresToSpawn)
        {
            item.SetActive(false);
        }
    }

    private void DropIfBelowEmpty()
    {
        //Make pieces drop down if the slot beneath them is empty
        //Needs 
    }

    private void FillOrePool()
    {
        foreach (GameObject item in magicOres)
        {
            for (int i = 0; i < 19; i++)
            {
                magicOresToSpawn.Add(Instantiate(item));
            }
        }
    }

    public void BreakOre(GameObject ore)
    {
        //broken ass function
        MagicOreScript _currentOreScript = ore.GetComponent<MagicOreScript>();

        int currentColumnIndex = _currentOreScript.columnIndex;
        int currentRowIndex = _currentOreScript.rowIndex;

        int _randomOre = Random.Range(0, magicOresToSpawn.Count);

        boardArray[currentColumnIndex, currentRowIndex] = null;
        magicOresToSpawn.Add(ore);
    }

    private void MagicOreRandomizer()
    {
        randomOre = Random.Range(0, 7);
        magicOre = magicOres[randomOre];
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowHeight; j++)
            {
                Handles.Label(boardArray[i, j].GetComponent<MagicOreScript>().transform.position, i + "," + j);
            }
        }
    }
}
