using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorInventory : Inventory
{
    public GameObject _vendorInventory;
    
    public Text _vendorGold;

    // Start is called before the first frame update
    void Start()
    {
        _vendorInventory.SetActive(true);
        _vendorGold.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
