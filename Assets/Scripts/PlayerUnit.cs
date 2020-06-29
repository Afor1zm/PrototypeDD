using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerUnit : Unit
{    
    public PlayerUnit _playerUnit;
    public Presenter _presenter;
    public GameLogic _gameLogic;
    public GUIUnitParameters _gui;
    public UIHealthBar uiHealthbar;
    public GameObject _playerObject;
    public int Level;
    //Vector2 endPosition;

    void Start()
    {
        Seed(true, 10, 15, 55, 10);
        _presenter.UnitGetRigidBody(_playerUnit);
        _playerUnit.State = States.ActiveWorld;
        _gui.GetUnit(_playerUnit);
        //endPosition = _presenter.GetEndPosition(_playerUnit);
    }
   
    void Update()
    {
        
        uiHealthbar.instance.SetValue(CurrentHealth / (float)Health);
        if (InBattle == false)
        {
            _presenter.PlayerMove(_playerUnit);
        } 
        
        if (_playerUnit.State == States.ActiveWorld)
        {
            _gameLogic.StopBattle();
        }        
    }    
}
