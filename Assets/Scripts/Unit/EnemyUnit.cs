using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : Unit
{    
    public EnemyUnit _enemyUnit;
    public Presenter _presenter;
    public UIHealthBar _uiHealthbar;
    public GameObject _enemyObject;
    public GameObject _enemyUIObject;
    Vector2 endPosition;
    
    void Awake()
    {
        Seed(false, 5, 15, 20, 5);
        _presenter.UnitGetRigidBody(_enemyUnit);
        endPosition = _presenter.GetEndPosition(_enemyUnit);
        Gold = 17;
        Expirience = 50;
    } 

    void Update()
    {
        if (_uiHealthbar != null)
        {
            _uiHealthbar._instance.SetValue(CurrentHealth / (float)Health);
        }
        
        if (endPosition != _enemyUnit.rigidbody2d.position)
        {
            _presenter.UnitMove(_enemyUnit, endPosition);
        }

        if (CurrentHealth <= 0)
        {
            Destroy(_enemyUIObject);
            if (!_enemyUnit.SpriteRenderer.isVisible & CurrentHealth <= 0)
            {
                Destroy(_enemyObject);
            }
        }       
    }
}
