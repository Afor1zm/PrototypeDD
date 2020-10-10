using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LevelUpButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject _plusButton;
    public PlayerUnit _playerUnit;
    public string _attributeName;
    public GameLogic _gameLogic;
   
    void Awake()
    {
        _plusButton.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_attributeName == _gameLogic._logicDictionary[2])
        {
            _playerUnit.Health = _playerUnit.Health + 15;
            _playerUnit.CurrentHealth = _playerUnit.Health;
        }
        if (_attributeName == _gameLogic._logicDictionary[3])
        {
            _playerUnit.Armor = _playerUnit.Armor + 10;
        }
        if (_attributeName == _gameLogic._logicDictionary[4])
        {
            _playerUnit.Damage = _playerUnit.Damage + 5;
        }

        _playerUnit._levelUpArmorButton._plusButton.SetActive(false);
        _playerUnit._levelUpDamageButton._plusButton.SetActive(false);
        _playerUnit._levelUpHealthButton._plusButton.SetActive(false);
    }    
}
