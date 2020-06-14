using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    public EnemyController enemyController;
    public Presenter _presenter;
    // Start is called before the first frame update
    void Start()
    {
        _presenter.UnitGetRigidBody(enemyController);
    }

    // Update is called once per frame
    void Update()
    {
        _presenter.UnitMove(enemyController);
    }
}
