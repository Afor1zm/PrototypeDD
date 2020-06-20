using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Presenter _presenter;
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
        //unit2.State = Unit.States.ActiveBattle;
        //unit1.State = Unit.States.WaitingInBattle;
    }
    public void Update()
    {
        
    }    
}
