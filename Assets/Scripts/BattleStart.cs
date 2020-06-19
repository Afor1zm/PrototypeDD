using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleStart : MonoBehaviour
{
    public PlayerController _player;
    public List<Unit> _battleUnitList = new List<Unit>();
    public Presenter _presenter;
    public EnemyController _enemyController1;
    public EnemyController _enemyController2;
    public EnemyController _enemyController3;
    public GameLogic _gameLogic;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.gameObject.ToString();
        Debug.Log(_enemyController1.InBattle + " " + _player.InBattle);
        // _presenter.UnitSetTriggerAttack(_enemyController1);
        //_presenter.UnitSetTriggerHurt(_enemyController2);
        // _presenter.UnitSetTriggerDie(_enemyController3);
        _battleUnitList.Add(_player);
        _battleUnitList.Add(_enemyController1);
        _battleUnitList.Add(_enemyController2);
        _battleUnitList.Add(_enemyController3);


        //Added to List works fine.
        _presenter.UnitSetTriggerHurt(_battleUnitList[0]);        

        _gameLogic.BattleStart(_battleUnitList);
        Debug.Log(_enemyController1.InBattle + " " + _player.InBattle);

        //_enemies.Add(new EnemyController(_enemyController.IsPlayerTeam, _enemyController.Initiative, _enemyController.Damage, _enemyController.Health, _enemyController.Armor));
        //_presenter.UnitSetTriggerDie(_enemies[0]);
        ////EnemyController _enemies = other.GetComponent<EnemyController>();
        //_presenter.UnitSetTriggerHurt(_player);
        //Debug.Log("asdasd");
    }
    
}
