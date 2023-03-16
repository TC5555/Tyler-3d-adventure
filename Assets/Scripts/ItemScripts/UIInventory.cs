using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    private void Awake()
    {
    
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            UIItems.Add(instance.GetComponentInChildren<UIItem>());
        
    }

    public void UpdateSlot(int slot, Item item)
    {
        UIItems[slot].UpdateItem(item);
    }
    public void AddNewItem(Item item)
    {
        UIItems.Add(new UIItem(item));
    }
    public void RemoveItem(Item item)
    {
        UpdateSlot(UIItems.FindIndex(i => i.item == item), null);
    }

}
