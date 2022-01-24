using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int movesLeft;
    
    private Vector2 mousePos;
    
    public GameObject currentOre;

    void Update()
    {
        GetMousePos();
        PlayerInput();
    }

    private void PlayerInput()
    {
        //Kolla att du klickar p� ore-helvetet med (till next time)
        if (Input.GetMouseButton(0) && currentOre != null)
        {
            currentOre.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0) && currentOre != null)
        {
            //currentOre.GetComponent<MagicOreScript>().boardPosition = currentOre.GetComponent<MagicOreScript>().swapPosition;
            //currentOre.transform.position = currentOre.GetComponent<MagicOreScript>().boardPosition;
            currentOre = null;
        }

    }

    private void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}