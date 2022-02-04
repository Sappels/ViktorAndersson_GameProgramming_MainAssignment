using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagicOreDrop : MonoBehaviour
{

    private void Update()
    {
        CheckInDir(transform.position, Vector2.down);
    }

    private void CheckInDir(Vector3 startPos, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, 1);
        if (hit.collider == null)
        {
            GetComponent<MagicOreScript>().boardPosition -= Vector2.down;
            //transform.DOMove(Vector3.down, 0.25f);
            //move down 1 unit
        }
        return;
    }


}
