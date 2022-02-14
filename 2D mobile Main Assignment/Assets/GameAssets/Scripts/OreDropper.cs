using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDropper : MonoBehaviour
{
    private Board board;
    private GameManager gameManager;
    [SerializeField] GameObject boardHandler;

    private void Start()
    {
        board = boardHandler.GetComponent<Board>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        CheckIfTopRowEmpty(transform.position, Vector2.down);
    }

    private void CheckIfTopRowEmpty(Vector3 startPos, Vector2 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, 1);
        if (hit.collider == null && !gameManager.isBoardFull)
        {
            int _randomOre = Random.Range(0, board.magicOresToSpawn.Count);
            GameObject newOre = board.magicOresToSpawn[_randomOre];

            board.magicOresToSpawn.RemoveAt(_randomOre);
            newOre.transform.position = transform.position + Vector3.down;
            newOre.transform.rotation = Quaternion.identity;
            newOre.transform.parent = boardHandler.transform;
            newOre.SetActive(true);
        }
        return;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down);

    }

}
