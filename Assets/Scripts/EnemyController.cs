using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    public EnemyController enemyController;
    public Presenter _presenter;
    public GameLogic _gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        Seed(false, 5, 15, 20, 5);
        _presenter.UnitGetRigidBody(enemyController);        
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
