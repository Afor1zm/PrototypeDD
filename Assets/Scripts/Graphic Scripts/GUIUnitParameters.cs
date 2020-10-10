using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIUnitParameters : MonoBehaviour
{
    public Unit _unit;
    public Text _healthLabel;
    public Text _armorLabel;
    public Text _damageLabel;    

    private void Awake()
    {
              
    }

    private void Update()
    {
        _healthLabel.text = $" {_unit.CurrentHealth}/{_unit.Health}";        
        _armorLabel.text = $"{_unit.Armor}";
        _damageLabel.text = $"{_unit.Damage}";
    }

    public Unit GetUnit(Unit unit)
    {
        return _unit = unit;
    }
}
