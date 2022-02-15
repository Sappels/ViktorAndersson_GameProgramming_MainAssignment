using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDropper : MonoBehaviour
{
    private Board board;
    private float delayTimer;
    [SerializeField] GameObject boardHandler;
    [SerializeField] float rayCastLength;

    public GameObject myColumnChecker;
    private ColumnChecker myColumn;

    private void Start()
    {
        board = boardHandler.GetComponent<Board>();
        myColumn = myColumnChecker.GetComponent<ColumnChecker>();
        delayTimer = 2f;
    }

    private void Update()
    {
        delayTimer -= Time.deltaTime;

        if (delayTimer <= 0)
        {
            CheckIfTopRowEmpty(transform.position, Vector2.down);
        }
    }

    private void CheckIfTopRowEmpty(Vector3 startPos, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, rayCastLength);
        if (hit.collider == null && !GameManager.Instance.isBoardFull && !myColumn.isColumnFull)
        {
            int _randomOre = Random.Range(0, board.magicOresToSpawn.Count);
            GameObject newOre = board.magicOresToSpawn[_randomOre];

            board.magicOresToSpawn.RemoveAt(_randomOre);
            newOre.transform.position = transform.position + Vector3.down;
            newOre.transform.rotation = Quaternion.identity;
            newOre.transform.parent = boardHandler.transform;
            newOre.SetActive(true);
            newOre.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.05f);
        }
        return;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (Vector2.down * rayCastLength));
    }

}
