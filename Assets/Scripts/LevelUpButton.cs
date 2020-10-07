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

    // Start is called before the first frame update
    void Start()
    {
        _plusButton.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_attributeName == "Health")
        {
            _playerUnit.Health = _playerUnit.Health + 15;
        }
        if (_attributeName == "Armor")
        {
            _playerUnit.Armor = _playerUnit.Armor + 10;
        }
        if (_attributeName == "Damage")
        {
            _playerUnit.Damage = _playerUnit.Damage + 5;
        }

        _playerUnit._levelUpArmorButton._plusButton.SetActive(false);
        _playerUnit._levelUpDamageButton._plusButton.SetActive(false);
        _playerUnit._levelUpHealthButton._plusButton.SetActive(false);
    }    
}
