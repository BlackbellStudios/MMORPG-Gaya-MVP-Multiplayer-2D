using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventoryScript inventory;
    [SerializeField]InventorySlot[] slots;
	// Use this for initialization
	void Start () {
        inventory = InventoryScript.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddITem(inventory.items[i]);
                Debug.Log("Adicionou item");
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
