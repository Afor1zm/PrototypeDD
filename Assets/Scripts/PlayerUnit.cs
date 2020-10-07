﻿using System.Collections;
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
    public int golden;
    public bool canTrade;
    public int Level;
    public List<int> _levelExpirience;
    public int nextLevelExpirience;
    public LevelUpButton _levelUpHealthButton;
    public LevelUpButton _levelUpDamageButton;
    public LevelUpButton _levelUpArmorButton;

    void Start()
    {
        Gold = 50;
        //easter egg
        _levelExpirience.Add(50);
        _levelExpirience.Add(110);
        _levelExpirience.Add(180);
        _levelExpirience.Add(260);
        _levelExpirience.Add(350);
        _levelExpirience.Add(450);
        _levelExpirience.Add(560);
        _levelExpirience.Add(680);
        Level = 0;
        nextLevelExpirience = _levelExpirience[0];
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

        
        golden = Gold;
        

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
            if (_vendorInventory.activeSelf == false)
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

        if (Expirience >= nextLevelExpirience)
        {
            Level += 1;
            NextLebel();
        }
    }

    public void NextLebel()
    {
        nextLevelExpirience = _levelExpirience[Level];
        Debug.Log(Level);
        _levelUpArmorButton._plusButton.SetActive(true);
        _levelUpDamageButton._plusButton.SetActive(true);
        _levelUpHealthButton._plusButton.SetActive(true);
    }
}
