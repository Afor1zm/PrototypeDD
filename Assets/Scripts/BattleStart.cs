using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEngine.UIElements;

public class BattleStart : MonoBehaviour
{
    public BattleStart _battleStart;

    // _battleTriggerZone need for GameLogic. It's need to know wich object should be destroy after battle.
    public GameObject _battleTriggerZone;
    public List<Unit> _battleUnitList = new List<Unit>();
    public List<Unit> _enemyList = new List<Unit>();
    public BattleLogic _battleLogic;
    public GameLogic _gameLogic;
    public PlayerUnit _playerUnit;
    private float playerPosition;
    public GameObject _unitUI;
    


    private void OnTriggerEnter2D(Collider2D other)
    {          
        Debug.Log(" " + other);
        playerPosition =_playerUnit.transform.position.x;
        _battleLogic.enabled=true;
        _battleUnitList.Add(other.GetComponent<Unit>());

        _battleLogic._deliteTriggerZone = _battleTriggerZone;
        _gameLogic.CreateOrcEnemy(playerPosition + 30.74f, -3.55f, -3f, _battleUnitList, _enemyList, _unitUI, 1067f);
        _gameLogic.CreateOrcEnemy(playerPosition + 33.74f, -3.55f, -3f, _battleUnitList, _enemyList, _unitUI, 1240f);
        _gameLogic.CreateOrcEnemy(playerPosition + 36.74f, -3.55f, -3f, _battleUnitList, _enemyList, _unitUI, 1413f);
        _battleLogic._battleUnitList = _battleUnitList;
        _battleLogic._enemyList = _enemyList;
        _battleLogic.StartBattle(other);
        _battleLogic._battleStart = _battleStart;
    }   
    
}
