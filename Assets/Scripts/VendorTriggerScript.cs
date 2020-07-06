using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorTriggerScript : MonoBehaviour
{
    public VendorUnit vendorUnit;    
    public PlayerUnit _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            _player.canTrade = true;
        }       
        vendorUnit.DisplayDialog();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            _player.canTrade = false;
        }
    }
}
