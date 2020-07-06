using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerUnit : Unit
{    
    public PlayerUnit _playerUnit;
    public Presenter _presenter;
    public GUIUnitParameters _gui;
    public UIHealthBar uiHealthbar;
    public GameLogic _gameLogic;    
    public GameObject _vendorInventory;
    public GameObject _playerInventory;    
    public GameObject _playerObject;
    public bool canTrade;
    public int Level;     

    void Start()
    {
        _playerInventory.SetActive(false);
        _vendorInventory.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            if(_vendorInventory.activeSelf == false)
            {
                _playerInventory.SetActive(!_playerInventory.activeSelf);
            }                        
        }


        if (canTrade)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (_playerInventory.activeSelf == _vendorInventory.activeSelf)
                {

                    _playerInventory.SetActive(!_playerInventory.activeSelf);
                    _vendorInventory.SetActive(!_vendorInventory.activeSelf);
                }
                else
                {
                    if (_playerInventory.activeSelf == false)
                    {

                        _playerInventory.SetActive(!_playerInventory.activeSelf);
                    }
                    else
                    {
                        _vendorInventory.SetActive(!_vendorInventory.activeSelf);
                    }
                }
            }
        }
        else
        {
            _vendorInventory.SetActive(false);
        }
    }    
}
