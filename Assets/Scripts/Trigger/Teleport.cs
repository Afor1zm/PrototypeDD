using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public PlayerUnit _playerUnit;
    public float _playerpositionx;
    public float _playerpositiony;
    public GameObject _teleportExit;   
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = _teleportExit.transform.position;
    }
}
