using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newITem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    InventoryScript inventory;
    void Start()
    {
        inventory = InventoryScript.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotindex)
    {
        if (currentEquipment[slotindex] != null)
        {
            Equipment oldItem = currentEquipment[slotindex];
            inventory.Add(oldItem);
            currentEquipment[slotindex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}


