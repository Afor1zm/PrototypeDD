using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorInventory : Inventory
{
    public GameObject EmptyItemSlot5;
    public GameObject EmptyItemSlot6;
    public GameObject EmptyItemSlot7;
    public GameObject EmptyItemSlot8;
    public GameObject _vendorInventory;    
    public Text _vendorGold;
    

    // Start is called before the first frame update
    void Start()
    {
        ItemList.Add(EmptyItemSlot1);
        ItemList.Add(EmptyItemSlot2);
        ItemList.Add(EmptyItemSlot3);
        ItemList.Add(EmptyItemSlot4);
        ItemList.Add(EmptyItemSlot5);
        ItemList.Add(EmptyItemSlot6);
        ItemList.Add(EmptyItemSlot7);
        ItemList.Add(EmptyItemSlot8);

        _vendorGold.text = "0";

        foreach (GameObject item in ItemList)
        {
            if (item.name == "EmptySlot")
            {
                PositionList.Add(item.transform.position);                
                slot = item.GetComponent<Item>();
                ItemLogicList.Add(slot);
                slot.EmptySlot = true;
            }
            else 
            {
                PositionList.Add(item.transform.position);
                slot = item.GetComponent<Item>();
                ItemLogicList.Add(slot);
                slot.EmptySlot = false;
            }
            
            //PositionList.Add(item.transform.position);
            //Debug.Log("added");
            //slot = item.GetComponent<Item>();
            //ItemLogicList.Add(slot);
            //slot.EmptySlot = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
