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
    public GameObject _parentUI;
    public Inventory _Inventory;    
    public VendorInventory _vendorInventory;
    public int itemIndex;
    public Item itemComponent;
    public GameLogic _gameLogic;
    

    public void Awake()
    {
        //_vendorInventory = GetComponentInParent<VendorInventory>();        
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        if ( _Inventory.ItemLogicList.All(p => p.EmptySlot == false))
        {
            Debug.Log("Inventory FULL");
        }
        else
        {
            itemIndex = _Inventory.GetFirstEmptySlot();
            if (_vendorInventory != null & _Inventory.ItemLogicList[itemIndex].EmptySlot == true)
            {                
                _gameLogic.TransferItem(_Inventory, this);
            }
        }        
    }
}
