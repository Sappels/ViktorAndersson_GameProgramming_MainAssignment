using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{
    [SerializeField] List<GameObject> friends;
    private GameObject bottomCollider;
    private GameObject objectPoolParent;
    private Player player;
    private Board board;

    public int columnIndex, rowIndex;
    public int oreType;

    public bool pickedUp;


    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<Player>();
        board = GameObject.FindGameObjectWithTag("BoardHandler").GetComponent<Board>();
        bottomCollider = GameObject.FindGameObjectWithTag("BottomCollider");
        objectPoolParent = GameObject.Find("ObjectPoolParent");
    }
    private void Update()
    {
        if (player.mouseDown)
        {
            GetComponent<Collider2D>().isTrigger = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            rb2d.gravityScale = 0;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = false;
            rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rb2d.gravityScale = 0.5f;
        }
    }

    private void OnMouseDown()
    {
        Vector2[] dirX = { Vector2.right, Vector2.left };
        CheckDir(dirX);
        
        Vector2[] dirY = { Vector2.up, Vector2.down };
        CheckDir(dirY);
    }

    private void OnMouseOver()
    {
        if (player.currentOre == null)
        {
            player.currentOre = gameObject;
        }
    }

    private void OnMouseExit()
    {
        if (player.currentOre == gameObject && !player.mouseDown)
        {
            player.currentOre = null;
        }
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

        if (friends.Count >= 3)
        {
            Debug.Log("3 friends, we can clear them");
            foreach (GameObject item in friends)
            {
                board.magicOresToSpawn.Add(item);
                item.transform.parent = objectPoolParent.transform;
                board.oresOnBoard.Remove(item);
                item.SetActive(false);
            }
            board.magicOresToSpawn.Add(gameObject);
            gameObject.transform.parent = objectPoolParent.transform;
            board.oresOnBoard.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void CheckInDir(Vector3 startPos, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, 1);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == bottomCollider)
                return;

            if (hit.collider.gameObject.GetComponent<MagicOreScript>().oreType == oreType)
            {
                hit.collider.enabled = false;
                startPos += (Vector3)direction;
                if (friends.Count < 5)
                {
                    friends.Add(hit.collider.gameObject);
                }
                CheckInDir(startPos, direction);
            }
        }
        return;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Vector2.up);
        Gizmos.DrawRay(transform.position, Vector2.down);
        Gizmos.DrawRay(transform.position, Vector2.left);
        Gizmos.DrawRay(transform.position, Vector2.right);
    }
}