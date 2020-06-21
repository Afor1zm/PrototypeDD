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
    
    public void StopBattle()
    {
        _battleLogic.enabled = false;
    }
}
