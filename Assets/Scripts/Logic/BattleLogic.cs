﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleLogic : MonoBehaviour
{
    private const float DELAY = 2f;
    public PlayerUnit _player;
    public List<Unit> _battleUnitList;
    public List<Unit> _enemyList;
    public Presenter _presenter;    
    public GameLogic _gameLogic;
    public BattleStart _battleStart;
    public GameObject _deliteTriggerZone;
    public Unit.States _states;
    public int numberActiveUnit;
    private Unit target;
    private int enemyCursor = 0;
    private bool IsEnemyTurn { get { return _battleUnitList[numberActiveUnit].State == Unit.States.ActiveBattle & _battleUnitList[numberActiveUnit].name != "Player"; } }



    private void LateUpdate()
    {        
        if (_enemyList?.Count == 0)
        {
            _player.InBattle = false;
            _player.State = Unit.States.ActiveWorld;
            _gameLogic.DeleteTriggeZone(_deliteTriggerZone);
        }

        if (IsEnemyTurn)
        {            
            Attack(_battleUnitList[numberActiveUnit], _player);
        }

        if (_player.State == Unit.States.ActiveBattle)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                NextTarget(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextTarget(1);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack(_player, target);
                if (_enemyList[0] != null)
                {
                    SwitchTarget(_enemyList[0]);
                } 
            }
        }
    }

    public void StartBattle(Collider2D other)
    {
        if (other.gameObject.name == _gameLogic._logicDictionary[1])
        {
            numberActiveUnit = 0;            
            _battleUnitList[0].State = Unit.States.ActiveBattle;
            SwitchTarget(_enemyList[enemyCursor]);

            _gameLogic.BattleStart(_battleUnitList);
            
            _battleUnitList[1].State = Unit.States.WaitingInBattle;
            _battleUnitList[2].State = Unit.States.WaitingInBattle;
            _battleUnitList[3].State = Unit.States.WaitingInBattle;
        }
    }

    public void Attack(Unit attacker, Unit victim)
    {        
        _presenter.UnitSetTriggerAttack(attacker);
        _presenter.UnitSetTriggerHurt(victim);
        var damage = victim.Armor - attacker.Damage;
        if (damage >0)
        {
            damage = 0;
        }
        victim.CurrentHealth = victim.CurrentHealth + damage;
        if (victim.CurrentHealth <= 0)
        {
            Death(attacker, victim);
        }

        numberActiveUnit ++;
        if (numberActiveUnit >= _battleUnitList.Count & _battleUnitList.Count !=0)
        {
            numberActiveUnit = 0;
        }

        StartCoroutine(SimpleWait(attacker));

    }

    IEnumerator SimpleWait(Unit unit1)
    {
        yield return new WaitForSeconds(DELAY);

        unit1.State = Unit.States.WaitingInBattle;
        _battleUnitList[numberActiveUnit].State = Unit.States.ActiveBattle;
    }

    private void SwitchTarget(Unit newTarget)
    {
        if (target != null)
        {
            _presenter.UnitSetUntarget(target);
        }
        target = newTarget;
        _presenter.UnitSetTarget(target);
    }

    private void NextTarget(int direction)
    {        
        enemyCursor = enemyCursor + direction;        
        if (_enemyList.Count != 1)
        {
            if (enemyCursor > _enemyList.Count - 1)
            {
                enemyCursor = 0;
            }            
            if (enemyCursor < 0)
            {
                enemyCursor = _enemyList.Count - 1;
            }
            SwitchTarget(_enemyList[enemyCursor]);
        }
        else {SwitchTarget(_enemyList[0]); }        
    }

    public void Death(Unit attacker, Unit victim)
    {
        _presenter.UnitSetTriggerDie(victim);
        _presenter.UnitSetUntarget(victim);
        _battleUnitList.Remove(_battleUnitList[_battleUnitList.IndexOf(victim)]);
        _enemyList.Remove(_enemyList[_enemyList.IndexOf(victim)]);
        _gameLogic.TransferGold(victim, attacker);
        _gameLogic.ReciveExpirience(victim, attacker);
    }
}
