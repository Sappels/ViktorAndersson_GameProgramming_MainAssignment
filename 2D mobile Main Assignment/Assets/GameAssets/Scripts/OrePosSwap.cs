using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrePosSwap : MonoBehaviour
{
    MagicOreScript magicOreScript;

    void Start()
    {
        magicOreScript = GetComponentInParent<MagicOreScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (magicOreScript.pickedUp)
        {
            if (other.CompareTag("PosSwapper"))
            {
                Debug.Log("I hit");
                magicOreScript.SwapPositions(other.transform.parent.gameObject);
            }
        }
    }
}
