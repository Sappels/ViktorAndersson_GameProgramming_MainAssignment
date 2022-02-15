using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnChecker : MonoBehaviour
{
    private LayerMask oreMask;

    private void Start()
    {
        oreMask = LayerMask.GetMask("MagicOre");
    }

    private void Update()
    {
        CheckIfColumnFull();
    }

    private void CheckIfColumnFull()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 10f, oreMask);
        
        if (hits.Length < 8)
        {
            GameManager.Instance.allowGravity = true;
        }

        if (hits.Length >= 8 && GameManager.Instance.isBoardFull)
        {
            GameManager.Instance.allowGravity = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (Vector2.down * 10f));
    }
}
