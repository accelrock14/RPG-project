using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment olditem);
    public OnEquipmentChanged onEquipmentChanged;

     void Start()
     {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        currentEquipment = new Equipment[numSlots];
     }
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment olditem = null;
        if (currentEquipment[slotIndex] != null)
        {
            olditem = currentEquipment[slotIndex];
            inventory.Add(olditem);
        }
        if(onEquipmentChanged!= null)
        {
            onEquipmentChanged.Invoke(newItem, olditem);
        }
        currentEquipment[slotIndex] = newItem;
    }
    public void UnEquip(int slotIndex)
    {
        if(currentEquipment[slotIndex]!= null)
        {
            Equipment olditem = currentEquipment[slotIndex];
            inventory.Add(olditem);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, olditem);
            }
        }
    }
    void UnEquidAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnEquidAll();
        }
    }
}
