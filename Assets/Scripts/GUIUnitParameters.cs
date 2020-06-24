using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIUnitParameters : MonoBehaviour
{    
    public Unit _unit;
    public Text _healthText;
    public Text _armorText;
    public Text _damageText;    

    private void Awake()
    {
              
    }

    private void Update()
    {
        _healthText.text = " " + _unit.CurrentHealth + "/" + _unit.Health;
        _armorText.text = " " + _unit.Armor;
        _damageText.text = " " + _unit.Damage;
    }

    public Unit GetUnit(Unit unit)
    {
        return _unit = unit;
    }
}
