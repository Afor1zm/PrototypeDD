using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{    
    public PlayerController playerController;
    public Presenter _presenter;
    //= new Unit(true,10,15,55,10)
    
    void Start()
    {
        SetParameters(true, 10, 15, 55, 10);
        _presenter.UnitGetRigidBody(playerController);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PlayerInitiative " + Initiative);
        _presenter.UnitMove(playerController);
    }    
}
