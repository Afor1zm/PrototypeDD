using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEngine.UIElements;

public class BattleStart : MonoBehaviour
{
    public GameObject battleTriggerZone;
    public List<Unit> _battleUnitList = new List<Unit>();
    public List<Unit> _enemyList = new List<Unit>();
    public BattleLogic _battleLogic;
    public GameObject _enemyObject;
    public GameLogic _gameLogic;
    public PlayerUnit _playerUnit;
    private float playerPosition;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" " + other);
        playerPosition =_playerUnit.transform.position.x;
        _battleLogic.enabled=true;
        _battleUnitList.Add(other.GetComponent<Unit>());

        _gameLogic.CreateOrcEnemy(playerPosition + 10, -3.55f, -3f, _battleUnitList, _enemyList);
        _gameLogic.CreateOrcEnemy(playerPosition + 12, -3.55f, -3f, _battleUnitList, _enemyList);
        _gameLogic.CreateOrcEnemy(playerPosition + 14f, -3.55f, -3f, _battleUnitList, _enemyList);
        _battleLogic._battleUnitList = _battleUnitList;
        _battleLogic._enemyList = _enemyList;
        _battleLogic.StartBattle(other); 
    }   
    
}
