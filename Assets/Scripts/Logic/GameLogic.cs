using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{    
    public BattleLogic _battleLogic;
    public Presenter _presenter;
    public GameObject _enemyObjectPrefab;
    public GameObject _enemyObject;
    public GameObject _uiObjectPrefab;
    public GameObject _uiObject;
    public GameObject _parentUI;
    public Inventory _playerInventory;
    public Inventory _vendorInventory;
    public Dictionary<int, string> _logicDictionary = new Dictionary<int, string>();
    private GUIUnitParameters GetGUIComponent;
    private Unit enemyObjectUnit;
    private UIHealthBar uiHealthBar;
    private EnemyUnit enemyUnitComponent;

    private void Awake()
    {
        _logicDictionary.Add(1, "Player");
        _logicDictionary.Add(2, "Health");
        _logicDictionary.Add(3, "Armor");
        _logicDictionary.Add(4, "Damage");
    }
    private void Start()
    {
        _battleLogic.enabled = false;
        //Application.targetFrameRate = 60;
    }

    public void BattleStart(List<Unit> unitList)
    {
        foreach (Unit unit in unitList)
        {
            unit.InBattle = true;
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
        enemyUnitComponent._uiHealthbar = uiHealthBar;        
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
            _playerInventory.Gold += giver.Gold;            
        }
        else
        {
            reciver.Gold += giver.Gold;
            _playerInventory.Gold -= giver.Gold;            
        }
    }

    public void ReciveExpirience(Unit giver, Unit reciver)
    {
        reciver.Expirience += giver.Expirience;
    }
    public void TransferItem(Inventory giver, Inventory reciever, Item item, GameObject nextParent)
    {        
        if (reciever._parentUnit.Gold - item.Cost >= 0)
        {
            item._item.transform.position = reciever.PositionList[item.itemIndex];
            item._item.transform.SetParent(nextParent.transform, true);
            reciever.ItemList[item.itemIndex] = item._item;
            reciever.ItemLogicList[item.itemIndex] = item;
            reciever.ItemLogicList[item.itemIndex].EmptySlot = false;
            giver.ItemLogicList[item.parentItemIndex] = giver.ParentEmptySlot.GetComponent<Item>();
            giver.ItemList[item.parentItemIndex] = giver.ParentEmptySlot;
            giver.ItemLogicList[item.parentItemIndex].EmptySlot = true;
            giver._parentUnit.Gold += item.Cost;
            giver._parentUnit.Armor -= item.Armor;
            giver._parentUnit.Damage -= item.Damage;
            giver._parentUnit.Health -= item.Health;
            reciever._parentUnit.Gold -= item.Cost;
            reciever._parentUnit.Armor += item.Armor;
            reciever._parentUnit.Damage += item.Damage;
            reciever._parentUnit.Health += item.Health;
        }
        else
        {
            Debug.Log("Not enough mineralz");
        }
               
    }
}
