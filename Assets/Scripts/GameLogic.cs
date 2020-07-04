using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{    
    public BattleLogic _battleLogic;
    public Presenter _presenter;
    public GameObject _enemyObjectPrefab;
    public GameObject _enemyObject;
    public GameObject _uiObjectPrefab;
    public GameObject _uiObject;
    public GameObject _parentUI;
    public Inventory _inventory;
    private GUIUnitParameters GetGUIComponent;
    private Unit enemyObjectUnit;
    private UIHealthBar uiHealthBar;
    private EnemyUnit enemyUnitComponent;
    


    private void Start()
    {
        _battleLogic.enabled = false;
        //Application.targetFrameRate = 60;
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
        
        _enemyObject = Instantiate(_enemyObjectPrefab, new Vector3(xCoordinate, yCoordinate, Zcoordinate), Quaternion.identity) as GameObject;
        enemyObjectUnit = _enemyObject.GetComponent<Unit>();
        enemyUnitComponent = _enemyObject.GetComponent<EnemyUnit>();
        enemyUnitComponent._enemyObject = _enemyObject;

        _battleUnitList.Add(enemyObjectUnit);
        _enemyList.Add(enemyObjectUnit);
        _presenter.UnitGetRigidBody(enemyObjectUnit);

        _uiObject = Instantiate(_uiObjectPrefab, new Vector3(unitUI.transform.position.x + distance, unitUI.transform.position.y, 0f), Quaternion.identity, _parentUI.transform);
        GetGUIComponent = _uiObject.GetComponent<GUIUnitParameters>();
        GetGUIComponent.GetUnit(enemyObjectUnit);
        enemyUnitComponent._enemyUIObject = _uiObject;

        uiHealthBar = _uiObject.GetComponentInChildren<UIHealthBar>();
        enemyUnitComponent.uiHealthbar = uiHealthBar;        
        _uiObjectPrefab.transform.SetParent(_parentUI.transform, false);
    }

    public void DeleteTriggeZone(GameObject battleTriggerZone)
    {
        if(battleTriggerZone != null)
        {
            Destroy(battleTriggerZone);
        }
        
    }

    public void TransferGold(Unit giver, Unit reciver)
    {
        if (reciver.IsPlayerTeam)
        {
            reciver.Gold += giver.Gold;
            _inventory.Gold += giver.Gold;
            _inventory._goldText.text = " " + _inventory.Gold;
        }
        else
        {
            reciver.Gold += giver.Gold;
            _inventory.Gold -= giver.Gold;
            _inventory._goldText.text = " " + _inventory.Gold;
        }
        
    }

    public void ReciveExpirience(Unit giver, Unit reciver)
    {
        reciver.Expirience += giver.Expirience;
    }
}
