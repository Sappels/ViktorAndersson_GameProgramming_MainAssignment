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
    public List<GameObject> magicOresToSpawn = new List<GameObject>();

    List<GameObject> oresOnBoard = new List<GameObject>();

    [SerializeField] GameObject objectPoolParent;
    private int randomOre;

    //I do not care about these bools for now they are just here so the if statements make some more sense

    void Start()
    {
        Application.targetFrameRate = 60;
        FillOrePool();
        CreateBoard();
        HideOrePoolAtStart();
    }

    private void CreateBoard()
    {
        for (int i = 0; i < columnLength; i++)
        {
            for (int j = 0; j < rowHeight; j++)
            {
                int _randomOre = Random.Range(0,magicOresToSpawn.Count);

                GameObject ore = magicOresToSpawn[_randomOre];
                
                oresOnBoard.Add(ore);
                ore.transform.parent = transform;
                ore.transform.localPosition = new Vector3(i, j, 0) * spacing;
                ore.transform.rotation = Quaternion.identity;
                magicOresToSpawn.RemoveAt(_randomOre);
                ore.SetActive(true);

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

    private void MagicOreRandomizer()
    {
        randomOre = Random.Range(0, magicOresToSpawn.Count);
        magicOre = magicOresToSpawn[randomOre];
    }
}
