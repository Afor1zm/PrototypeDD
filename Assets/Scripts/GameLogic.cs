using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public BattleLogic _battleLogic;
    public Presenter _presenter;    

    private void Start()
    {
        _battleLogic.enabled = false;
    }
    public void BattleStart(List<Unit> unitList)
    {
        foreach (Unit Inbattle in unitList)
        {
            Inbattle.InBattle = true;
        }        
    }

    public void Attack(Unit unit1, Unit unit2)
    {
        _presenter.UnitSetTriggerAttack(unit1);
        _presenter.UnitSetTriggerHurt(unit2);
        unit2.CurrentHealth = unit2.CurrentHealth + unit2.Armor - unit1.Damage;
        if (unit2.CurrentHealth <= 0)
        {
            _presenter.UnitSetTriggerDie(unit2);
            _presenter.UnitSetUntarget(unit2);
        }
        //unit2.State = Unit.States.ActiveBattle;
        //unit1.State = Unit.States.WaitingInBattle;
    }
    
    public void StopBattle()
    {
        _battleLogic.enabled = false;
    }
}
