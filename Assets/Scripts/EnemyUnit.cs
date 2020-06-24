using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    public EnemyUnit _enemyUnit;
    public Presenter _presenter;
    public UIHealthBar uiHealthbar;

    // Start is called before the first frame update
    void Awake()
    {
        Seed(false, 5, 15, 20, 5);
        _presenter.UnitGetRigidBody(_enemyUnit);
        
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiHealthbar.SetValue(CurrentHealth / (float)Health);
    }
}
