using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{    
    public int Gold { get; set; }
    public Text _goldText;
    public List<GameObject> _itemList;
    public GameObject emptyItemSlot1;
    public GameObject emptyItemSlot2;
    public GameObject emptyItemSlot3;
    public GameObject emptyItemSlot4;

    // Start is called before the first frame update
    void Start()
    {
        _goldText.text = "0";
        _itemList.Add(emptyItemSlot1);
        _itemList.Add(emptyItemSlot2);
        _itemList.Add(emptyItemSlot3);
        _itemList.Add(emptyItemSlot4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
