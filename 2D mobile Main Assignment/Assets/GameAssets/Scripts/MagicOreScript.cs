using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{

    List<GameObject> friends;
    private int mana = 100;
    
    public bool pickedUp;
    
    public int columnIndex, rowIndex;
    public int oreType;
    public Vector2 boardPosition;

    private void Start()
    {
        boardPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!pickedUp)
        {
            transform.localPosition = boardPosition;
        }
        else
        {
            Debug.Log(boardPosition);
        }
    }

    public int GetMana()
    {
        return mana;
    }


    private void OnMouseDown()
    {
        GetComponent<Collider2D>().enabled = false;

        Vector2[] dirX = { Vector2.right, Vector2.left };
        CheckDir(dirX);

        Vector2[] dirY = { Vector2.up, Vector2.down };
        CheckDir(dirY);

        GetComponent<Collider2D>().enabled = true;
    }

    private void CheckDir(Vector2[] dir)
    {
        friends = new List<GameObject>();

        foreach (var direction in dir)
        {
            CheckInDir(transform.position, direction);
        }

        foreach (var item in friends)
        {
            item.GetComponent<Collider2D>().enabled = true;
        }

        if (friends.Count >= 2)
        {
            Debug.Log("3 friends, we can clear them");
            foreach (GameObject item in friends)
            {
                item.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }

    private void CheckInDir(Vector3 startPos, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, 1);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<MagicOreScript>().oreType == oreType)
            {
                hit.collider.enabled = false;
                startPos += (Vector3)direction;
                if (friends.Count < 3)
                {
                    friends.Add(hit.collider.gameObject);
                }
                CheckInDir(startPos, direction);
            }
        }
        return;
    }
}
