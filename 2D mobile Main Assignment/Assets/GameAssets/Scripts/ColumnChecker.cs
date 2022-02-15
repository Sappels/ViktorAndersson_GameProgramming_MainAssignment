using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnChecker : MonoBehaviour
{
    private LayerMask oreMask;
    private float timer;

    public bool isColumnFull;

    private void Start()
    {
        oreMask = LayerMask.GetMask("MagicOre");
        timer = 0.5f;
    }

    private void Update()
    {
        CheckIfColumnFull();
    }

    private void CheckIfColumnFull()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 15f, oreMask);

        if (hits.Length < 8)
        {
            GameManager.Instance.allowGravity = true;
            isColumnFull = false;
        }

        if (hits.Length >= 8)
        {
            isColumnFull = true;
        }

        if (hits.Length >= 8 && GameManager.Instance.isBoardFull)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameManager.Instance.allowGravity = false;
                timer = 0.5f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (Vector2.down * 15f));
    }
}
