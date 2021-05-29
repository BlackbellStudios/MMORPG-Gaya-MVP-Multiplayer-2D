using UnityEngine;

public class ItemPickup : Interactable {
    public Item item;
   
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
	
    void PickUp()
    {
   
        Debug.Log("Pegando Item" +item.name);
        //Adicionar o item ao inventário
        bool wasPickUp = InventoryScript.instance.Add(item);
        if(wasPickUp)
        {
            Destroy(gameObject);
        }
        

    }
}
