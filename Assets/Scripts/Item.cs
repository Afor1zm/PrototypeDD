using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public bool EmptySlot { get; set; }
    public GameObject _item;       
    public GameObject _playerInventoryObject;
    public GameObject _vendorInventoryObject;
    public GameObject _parentInventory;
    public GameLogic _gameLogic;
    public VendorInventory _vendorInventory;
    public PlayerInventory _playerInventory;
    public int itemIndex;
    public int parentItemIndex;  
    private VendorInventory vendorInventory;
    private PlayerInventory playerInventory;

    public void OnPointerClick(PointerEventData eventData)
    {
        vendorInventory = _item.GetComponentInParent<VendorInventory>();
        playerInventory = _item.GetComponentInParent<PlayerInventory>();

        if (playerInventory !=null & _item.name != "EmptySlot")
        {
            Methods(_playerInventory, _vendorInventory, _playerInventoryObject, _vendorInventoryObject);            
        }

        if (vendorInventory !=null & _item.name != "EmptySlot")
        {
            Methods(_vendorInventory, _playerInventory, _vendorInventoryObject, _playerInventoryObject);            
        }        
    }

    public void Methods(Inventory giver, Inventory reciever, GameObject parentInventory, GameObject nextParentObject)
    {
        _parentInventory = parentInventory;
        parentItemIndex = giver.GetIndexItem(this);
        if (reciever.ItemLogicList.All(p => p.EmptySlot == false))
        {
            Debug.Log("Inventory FULL");
        }
        else
        {
            itemIndex = reciever.GetFirstEmptySlot();
            if (giver != null & reciever.ItemLogicList[itemIndex].EmptySlot == true)
            {
                _gameLogic.TransferItem(giver, reciever, this, nextParentObject);
            }
        }
    }
}
