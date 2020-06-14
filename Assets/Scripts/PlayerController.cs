using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{    
    public PlayerController playerController;
    public Presenter _presenter;

    // Start is called before the first frame update
    void Start()
    {
        _presenter.UnitGetRigidBody(playerController);
    }

    // Update is called once per frame
    void Update()
    {

        _presenter.UnitMove(playerController);
    }    
}
