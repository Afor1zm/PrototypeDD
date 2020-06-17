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
        SetParameters(false, 5, 7, 20, 3);
        _presenter.UnitGetRigidBody(enemyController);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PlayerInitiative " + Initiative);
        
    }
}
