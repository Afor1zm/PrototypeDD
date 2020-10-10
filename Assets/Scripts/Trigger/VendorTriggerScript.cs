using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorTriggerScript : MonoBehaviour
{
    public VendorUnit vendorUnit;    
    public PlayerUnit _player;
    public GameLogic _gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == _gameLogic._logicDictionary[1])
        {
            _player.canTrade = true;
        }       
        vendorUnit.DisplayDialog();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == _gameLogic._logicDictionary[1])
        {
            _player.canTrade = false;
        }
    }
}