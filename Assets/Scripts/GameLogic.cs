using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{    
    public BattleLogic _battleLogic;
    public Presenter _presenter;
    public GameObject _enemyObject; 

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

    public void CreateOrcEnemy(float xCoordinate, float yCoordinate, float Zcoordinate, List<Unit> _battleUnitList, List<Unit> _enemyList)
    {
        _enemyObject = Instantiate(_enemyObject, new Vector3(xCoordinate, yCoordinate, Zcoordinate), Quaternion.identity) as GameObject;
        _battleUnitList.Add(_enemyObject.GetComponent<Unit>());
        _enemyList.Add(_enemyObject.GetComponent<Unit>());
        _presenter.UnitGetRigidBody(_enemyObject.GetComponent<Unit>());
    }

    public void DeleteTriggeZone(GameObject battleTriggerZone)
    {
        Destroy(battleTriggerZone);
    }
}
