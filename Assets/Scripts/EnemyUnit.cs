using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    public EnemyUnit _enemyController;
    public Presenter _presenter;
    

    // Start is called before the first frame update
    void Start()
    {
        Seed(false, 5, 15, 20, 5);
        _presenter.UnitGetRigidBody(_enemyController);        
    }

    // Update is called once per frame
    void Update()
    {       

    }
}
