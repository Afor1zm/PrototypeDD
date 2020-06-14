using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    public float Speed { get; set; }
    public bool IsPlayerTeam { get; set; }
    public int Initiative { get; set; }
    public bool Active { get; set; }
    public int Damage { get; set; }
    public int Health { get; set; }
    public int CurrentHealth { get; set; }
    public int Armor { get; set; }
    public bool Alive { get; set; }
    public bool InBattle { get; set; }
    public Rigidbody2D rigidbody2d { get; set; }
    public Vector2 lookDirection { get; set; } = new Vector2(1, 0);
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }    
}
