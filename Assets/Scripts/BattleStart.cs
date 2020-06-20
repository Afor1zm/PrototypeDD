using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEngine.UIElements;

public class BattleStart : MonoBehaviour
{    
    public BattleLogic _battleLogic; 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _battleLogic.StartBattle(other);     
    }
}
