using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleLogic : MonoBehaviour
{
    private const float DELAY = 2f;
    private Unit _target;
    private int enemyCursor = 0;

    private bool IsEnemyTurn { get { return _battleUnitList[numberActiveUnit].State == Unit.States.ActiveBattle & _battleUnitList[numberActiveUnit].name != "Player"; } }

    public PlayerUnit _player;
    public List<Unit> _battleUnitList;
    public List<Unit> _enemyList;
    public Presenter _presenter;    
    public GameLogic _gameLogic;
    public BattleStart _battleStart;
    
    public Unit.States states;       
    public int numberActiveUnit;


    private void LateUpdate()
    {        
        if (_enemyList?.Count == 0)
        {
            _player.InBattle = false;
            _player.State = Unit.States.ActiveWorld;
            _gameLogic.DeleteTriggeZone(_battleStart._battleTriggerZone);
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
                Attack(_player, _target);
                SwitchTarget(_enemyList[0]);
            }
        }
    }

    public void StartBattle(Collider2D other)
    {
        if (other.gameObject.name == "Player")
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
        victim.CurrentHealth = victim.CurrentHealth + victim.Armor - attacker.Damage;
        if (victim.CurrentHealth <= 0)
        {            
            _presenter.UnitSetTriggerDie(victim);
            _presenter.UnitSetUntarget(victim);
            _battleUnitList.Remove(_battleUnitList[_battleUnitList.IndexOf(victim)]);
            _enemyList.Remove(_enemyList[_enemyList.IndexOf(victim)]);
        }

        numberActiveUnit = numberActiveUnit + 1;
        if (numberActiveUnit >= _battleUnitList.Count)
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
        if (_target != null)
        {
            _presenter.UnitSetUntarget(_target);
        }
        _target = newTarget;
        _presenter.UnitSetTarget(_target);
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
}
