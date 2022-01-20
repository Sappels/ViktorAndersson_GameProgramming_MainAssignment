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
        //Kolla att du klickar på ore-helvetet med (till next time)
        if (Input.GetMouseButton(0) && currentOre != null)
        {
            currentOre.transform.position = mousePos;
            //bingbangbom dra i ores då
        }
    }

    private void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}