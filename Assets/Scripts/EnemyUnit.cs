using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : Unit
{    
    public EnemyUnit _enemyUnit;
    public Presenter _presenter;
    public UIHealthBar uiHealthbar;
    public GameObject _enemyObject;
    public GameObject _enemyUIObject;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Seed(false, 5, 15, 20, 5);
        _presenter.UnitGetRigidBody(_enemyUnit);
        endPosition = _presenter.GetEndPosition(_enemyUnit);
        Gold = 17;
        Expirience = 50;
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiHealthbar != null)
        {
            uiHealthbar.instance.SetValue(CurrentHealth / (float)Health);
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
