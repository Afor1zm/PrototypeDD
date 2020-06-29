using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public PlayerUnit playerUnit;
    public float playerpositionx;
    public float playerpositiony;
    public GameObject teleport;
    //public Camera camera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = teleport.transform.position;
    }
}
