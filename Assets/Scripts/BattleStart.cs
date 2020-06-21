using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;
using UnityEngine.UIElements;

public class BattleStart : MonoBehaviour
{
    public List<Unit> _battleUnitList = new List<Unit>();
    public BattleLogic _battleLogic;
    public GameObject _enemyObject;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _battleLogic.StartBattle(other);        
        _battleLogic.enabled=true;
        //_battleUnitList.Add(other.GetComponent<Unit>());
        //Instantiate(_enemyObject, new Vector3 (6f, -4f, -3f), Quaternion.identity);
        //_battleUnitList.Add(_enemyObject.GetComponent<Unit>());
        //Instantiate(_enemyObject, new Vector3(11f, -4f, -3f), Quaternion.identity);
        //_battleUnitList.Add(_enemyObject.GetComponent<Unit>());
        //Instantiate(_enemyObject, new Vector3(8f, -4f, -3f), Quaternion.identity);
        //_battleUnitList.Add(_enemyObject.GetComponent<Unit>());
        //_battleLogic._battleUnitList = _battleUnitList;
    }    
}
