using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour
{    
    public int Gold { get; set; }
    public Text GoldLabel;
    public List<GameObject> ItemList;
    public List<Vector3> PositionList;
    public List<Item> ItemLogicList;
    public GameObject ParentEmptySlot;
    public GameObject EmptyItemSlot1;
    public GameObject EmptyItemSlot2;
    public GameObject EmptyItemSlot3;
    public GameObject EmptyItemSlot4;    
    public Item slot;
    public Unit _parentUnit;
    public Dictionary<int, string> _inventoryDictionary = new Dictionary<int, string>();

    private void Awake()
    {
        _inventoryDictionary.Add(1,"EmptySlot");
    }

    public int GetFirstEmptySlot()
    {
        var itemSlot = ItemLogicList.IndexOf(ItemLogicList.First(p => p.EmptySlot == true));        
        return itemSlot;
    }

    public int GetIndexItem(Item item)
    {
        var itemindex = ItemLogicList.IndexOf(item);
        return itemindex;
    }
    public void ShowEmpty(List<Item> itemlogic)
    {
        foreach (Item item in itemlogic)
        {
            Debug.Log(" " + item.EmptySlot);
        }
    }
}
