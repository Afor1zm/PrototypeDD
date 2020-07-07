using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour
{    
    public int Gold { get; set; }
    public Text GoldText { get; set; }
    public List<GameObject> ItemList;
    public List<Vector3> PositionList;
    public List<Item> ItemLogicList;
    public GameObject EmptyItemSlot1;
    public GameObject EmptyItemSlot2;
    public GameObject EmptyItemSlot3;
    public GameObject EmptyItemSlot4;    
    public Item slot;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
