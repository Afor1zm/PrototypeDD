using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Inventory
{    
    void Start()
    {
        GoldLabel.text = "" + _parentUnit.Gold;        
        ItemList.Add(EmptyItemSlot1);
        ItemList.Add(EmptyItemSlot2);
        ItemList.Add(EmptyItemSlot3);
        ItemList.Add(EmptyItemSlot4);

        foreach (GameObject item in ItemList)
        {
            PositionList.Add(item.transform.position);            
            slot = item.GetComponent<Item>();
            ItemLogicList.Add(slot);
            slot.EmptySlot = true;
        }
    }

    void Update()
    {
        GoldLabel.text = "" + _parentUnit.Gold;
    }
}
