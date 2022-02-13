using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharectorStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }
    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }
        if(oldItem != null)
        {
            armor.AddModifier(oldItem.armorModifier);
            damage.AddModifier(oldItem.damageModifier);
        }
    }
}
