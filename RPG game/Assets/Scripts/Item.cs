using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "new item";
    public Sprite icon = null;
    public bool isDefault = false;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }
}
