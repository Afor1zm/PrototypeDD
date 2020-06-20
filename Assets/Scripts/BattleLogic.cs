using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogic : MonoBehaviour
{
    public PlayerController _player;
    public List<Unit> _battleUnitList = new List<Unit>();
    public List<EnemyController> _enemyList = new List<EnemyController>();
    public Presenter _presenter;
    public EnemyController _enemyController1;
    public EnemyController _enemyController2;
    public EnemyController _enemyController3;
    public GameLogic _gameLogic;    
    public Unit.States states;
    public int target;
    public int untarget;

    private void LateUpdate()
    {
        Debug.Log("Update");
        try
        {
            if (_enemyList[0].CurrentHealth <= 0 & _enemyList[1].CurrentHealth <= 0 & _enemyList[2].CurrentHealth <= 0)
            {
                _player.InBattle = false;
                _player.State = Unit.States.ActiveWorld;                
            }
        }
        catch
        {

        }

        if (_player.State == Unit.States.ActiveBattle)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                target = target + 1;
                untarget = target - 1;
                if (target > 2)
                {
                    target = 0;
                }
                _presenter.UnitSetTarget(_enemyList[target]);
                if (untarget < 0)
                {
                    untarget = 2;
                }
                _presenter.UnitSetUntarget(_enemyList[untarget]);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                target = target - 1;
                untarget = target + 1;
                if (target < 0)
                {
                    target = 2;
                }
                _presenter.UnitSetTarget(_enemyList[target]);
                if (untarget > 2)
                {
                    untarget = 0;
                }
                _presenter.UnitSetUntarget(_enemyList[untarget]);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameLogic.Attack(_player, _enemyList[target]);
                Debug.Log("LOG " + _enemyList[target].CurrentHealth + " untarget " + untarget);
            }
        }
    }
    public void StartBattle(Collider2D other)
    {        
        if (other.gameObject.name == "Player")
        {
            target = 0;
            untarget = target;
            
            _battleUnitList.Add(_player);
            _battleUnitList.Add(_enemyController1);
            _battleUnitList.Add(_enemyController2);
            _battleUnitList.Add(_enemyController3);
            _enemyList.Add(_enemyController1);
            _enemyList.Add(_enemyController2);
            _enemyList.Add(_enemyController3);
            
            _presenter.UnitSetTarget(_enemyList[target]);

            _gameLogic.BattleStart(_battleUnitList);
            Debug.Log("LOG " + _enemyList[target].CurrentHealth + " untarget " + untarget);
            _player.State = Unit.States.ActiveBattle;
            _enemyController1.State = Unit.States.WaitingInBattle;
            _enemyController2.State = Unit.States.WaitingInBattle;
            _enemyController3.State = Unit.States.WaitingInBattle;
        }
    }
}
