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

    private Inventory inventory;
    private VendorInventory vendorInventory;
    private PlayerInventory playerInventory;
    private Item itemComponent;
    
    public void Awake()
    {        
        inventory = _item.GetComponentInParent<Inventory>();
        itemComponent = _item.GetComponent<Item>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        vendorInventory = _item.GetComponentInParent<VendorInventory>();
        playerInventory = _item.GetComponentInParent<PlayerInventory>();

        if (playerInventory !=null & _item.name != "EmptySlot")
        {
            _parentInventory = _vendorInventoryObject;
            parentItemIndex = playerInventory.GetIndexItem(this);
            itemIndex = _vendorInventory.GetFirstEmptySlot();
            Debug.Log(" " + parentItemIndex);
            if (_vendorInventory != null & _vendorInventory.ItemLogicList[itemIndex].EmptySlot == true)
            {
                _gameLogic.TransferItem(_playerInventory, _vendorInventory, this, _parentInventory);
                playerInventory.ItemLogicList[parentItemIndex].EmptySlot = true;
            }
        }

        if (vendorInventory !=null & _item.name != "EmptySlot")
        {
            _parentInventory = _playerInventoryObject;
            parentItemIndex = vendorInventory.GetIndexItem(this);
            Debug.Log(" " + parentItemIndex);
            if (_playerInventory.ItemLogicList.All(p => p.EmptySlot == false))
            {
                Debug.Log("Inventory FULL");
            }
            else
            {
                itemIndex = _playerInventory.GetFirstEmptySlot();
                if (_vendorInventory != null & _playerInventory.ItemLogicList[itemIndex].EmptySlot == true)
                {
                    _gameLogic.TransferItem(_vendorInventory, _playerInventory, this, _parentInventory);
                    vendorInventory.ItemLogicList[parentItemIndex].EmptySlot = true;
                }
            }
        }           
    }
}
