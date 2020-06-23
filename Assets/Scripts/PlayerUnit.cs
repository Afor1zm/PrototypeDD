using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{    
    public PlayerUnit _playerController;
    public Presenter _presenter;
    public GameLogic _gameLogic;
    public GUIUnitParameters _gui;
    //public UIHealthBar uiHealthbar;

    void Start()
    {
        Seed(true, 10, 15, 55, 10);
        _presenter.UnitGetRigidBody(_playerController);
        _playerController.State = States.ActiveWorld;
        _gui.GetUnit(_playerController);
    }
   
    void Update()
    {
        UIHealthBar.instance.SetValue(CurrentHealth / (float)Health);
        if (InBattle == false)
        {
            _presenter.UnitMove(_playerController);
        } 
        
        if (_playerController.State == States.ActiveWorld)
        {
            _gameLogic.StopBattle();
        }
    }    
}
