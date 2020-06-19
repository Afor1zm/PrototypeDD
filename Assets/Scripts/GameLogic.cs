using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<Unit> _battleUnitList;
    public void BattleStart(List<Unit> battleLogic)
    {
        foreach (Unit Inbattle in battleLogic)
        {
            Inbattle.InBattle = true;
        }
    }
}
