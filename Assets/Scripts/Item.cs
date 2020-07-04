using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public bool EmptySlot { get; set; }
    public GameObject _item;
    public GameObject _playerInventory;
    public GameObject _playerItem;
    public GameObject _parentUI;
    private VendorInventory _vendorInventory;

    public void Awake()
    {
        _vendorInventory = GetComponentInParent<VendorInventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_vendorInventory != null) 
        {
            Debug.Log("lols");
            _playerItem = Instantiate(_item, new Vector3(_playerInventory.transform.position.x + 10f, _playerInventory.transform.position.y, 0f), Quaternion.identity, _parentUI.transform);
            Destroy(_item);
        }
        
    }
}
