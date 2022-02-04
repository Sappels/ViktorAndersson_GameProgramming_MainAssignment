using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    //[SerializeField] GameObject capsule;
    //[SerializeField] GameObject capsule2;
    [SerializeField] int movesLeft;
    [SerializeField] Board board;
    private Vector2 mousePos;

    private bool mouseDown;
    private bool hLock;
    private bool vLock;

    public GameObject currentOre;

    void Update()
    {
        GetMousePos();
        PlayerInput();
        //Debug.Log("Distance " + Vector2.Distance(board.boardArray[0, 7].GetComponent<MagicOreScript>().boardPosition, board.boardArray[0, 6].GetComponent<MagicOreScript>().boardPosition));
        //Debug.Log("mousePos "+ mousePos);

        if (Input.GetKey(KeyCode.B))
        {
            if (currentOre != null)
            {
                board.BreakOre(currentOre);
            }
        }
    }

    private void PlayerInput()
    {
        if (!mouseDown)
        {
            if (mousePos.x > 7f || mousePos.y > 7f) return;
            if (mousePos.x < 0f || mousePos.y < 0f) return;

            currentOre = board.boardArray[(int)mousePos.x, (int)mousePos.y];
        }

        if (Input.GetMouseButton(0) && currentOre != null)
        {
            mouseDown = true;
            MagicOreScript _currentOreScript = currentOre.GetComponent<MagicOreScript>();

            currentOre.GetComponent<MagicOreScript>().pickedUp = true;

            currentOre.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 offset = (Vector2)_currentOreScript.transform.position - _currentOreScript.boardPosition;

            if (Mathf.Abs(offset.x) >= 1 || Mathf.Abs(offset.y) >= + 1)
            {
                board.boardArray[(int)_currentOreScript.boardPosition.x, (int)_currentOreScript.boardPosition.y] = board.boardArray[(int)mousePos.x, (int)mousePos.y];
                board.boardArray[(int)mousePos.x, (int)mousePos.y] = currentOre;
            }
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