using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public bool EmptySlot { get; set; }
    public GameObject _item;
    public GameObject _playerInventory;
    public GameObject _playerItem;
    public GameObject _parentUI;
    public Inventory _Inventory;    
    public VendorInventory _vendorInventory;   
    

    public void Awake()
    {
        _vendorInventory = GetComponentInParent<VendorInventory>();
        _Inventory = _playerInventory.GetComponent<Inventory>();       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ( _Inventory.ItemLogicList.All(p => p.EmptySlot == false))
        {
            Debug.Log("Inventory FULL");
        }
        else
        {
            if (_vendorInventory != null & _Inventory.ItemLogicList[_Inventory.GetFirstEmptySlot()].EmptySlot == true)
            {                
                _playerItem = Instantiate(_item, new Vector3(_Inventory.PositionList[_Inventory.GetFirstEmptySlot()].x, _Inventory.PositionList[_Inventory.GetFirstEmptySlot()].y, _Inventory.PositionList[_Inventory.GetFirstEmptySlot()].z), Quaternion.identity, _parentUI.transform);
                _Inventory.ItemLogicList[_Inventory.GetFirstEmptySlot()].EmptySlot = false;
                _item.transform.SetParent(_parentUI.transform, false);
                Destroy(_item);
            }
        }        
    }

    public void Update()
    {
        
    }
}
