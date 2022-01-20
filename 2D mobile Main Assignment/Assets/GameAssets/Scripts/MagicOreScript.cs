using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOreScript : MonoBehaviour
{
    private GameObject playerHandler;
    private Player player;
        

    private void Start()
    {
        playerHandler = GameObject.FindGameObjectWithTag("PlayerHandler");
        player = playerHandler.GetComponent<Player>();
    }

    private void OnMouseEnter()
    {
        player.currentOre = this.gameObject;
    }
    private void OnMouseExit()
    {
        player.currentOre = null;
    }

}
