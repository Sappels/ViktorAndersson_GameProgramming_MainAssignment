using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] int movesLeft;
    [SerializeField] Board board;
    private Vector2 mousePos;

    public bool mouseDown;

    public GameObject currentOre;

    void Update()
    {
        GetMousePos();
        PlayerInput();
    }

    private void PlayerInput()
    {
        //if (!mouseDown)
        //{
        //    if (mousePos.x > 7f || mousePos.y > 7f) return;
        //    if (mousePos.x < 0f || mousePos.y < 0f) return;
        //
        //    currentOre = board.boardArray[(int)mousePos.x, (int)mousePos.y];
        //}

        if (Input.GetMouseButton(0) && currentOre != null)
        {
            mouseDown = true;
            MagicOreScript _currentOreScript = currentOre.GetComponent<MagicOreScript>();

            _currentOreScript.pickedUp = true;
        
            currentOre.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            //Vector2 offset = (Vector2)_currentOreScript.transform.position - _currentOreScript.boardPosition;
        
            //if (Mathf.Abs(offset.x) >= 1 || Mathf.Abs(offset.y) >= + 1)
            //{
            //    board.boardArray[(int)_currentOreScript.boardPosition.x, (int)_currentOreScript.boardPosition.y] = board.boardArray[(int)mousePos.x, (int)mousePos.y];
            //    board.boardArray[(int)mousePos.x, (int)mousePos.y] = currentOre;
            //}
        }

        if (Input.GetMouseButtonUp(0) && currentOre != null)
        {
            mouseDown = false;
            currentOre.GetComponent<MagicOreScript>().pickedUp = false;
            currentOre = null;
        }
    }

    private void GetMousePos()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - board.transform.position);
        mousePos.x = Mathf.Round(mousePos.x);
        mousePos.y = Mathf.Round(mousePos.y);
    }
}