using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{    
    public BattleLogic _battleLogic;
    public Presenter _presenter;
    public GameObject _enemyObject;
    public GameObject _uiObject;
    public GameObject _parentUI;    
    private GUIUnitParameters GetGUIComponent;
    private Unit enemyObjectUnit;
    private UIHealthBar uiHealthBar;
    private EnemyUnit enemyUnitComponent;


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

    public void CreateOrcEnemy(float xCoordinate, float yCoordinate, float Zcoordinate, List<Unit> _battleUnitList, List<Unit> _enemyList, GameObject unitUI, float distance)
    {
        
        _enemyObject = Instantiate(_enemyObject, new Vector3(xCoordinate, yCoordinate, Zcoordinate), Quaternion.identity) as GameObject;
        enemyObjectUnit = _enemyObject.GetComponent<Unit>();
        enemyUnitComponent = _enemyObject.GetComponent<EnemyUnit>();

        _battleUnitList.Add(enemyObjectUnit);
        _enemyList.Add(enemyObjectUnit);
        _presenter.UnitGetRigidBody(enemyObjectUnit);

        _uiObject = Instantiate(_uiObject, new Vector3(unitUI.transform.position.x + distance, unitUI.transform.position.y, 0f), Quaternion.identity, _parentUI.transform);
        GetGUIComponent = _uiObject.GetComponent<GUIUnitParameters>();
        GetGUIComponent.GetUnit(enemyObjectUnit);

        uiHealthBar = _uiObject.GetComponentInChildren<UIHealthBar>();
        enemyUnitComponent.uiHealthbar = uiHealthBar;        
        _uiObject.transform.SetParent(_parentUI.transform, false);
    }

    public void DeleteTriggeZone(GameObject battleTriggerZone)
    {
        Destroy(battleTriggerZone);
    }
}
