using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour {
    public GameObject shopUI;
    InventoryScript updateInventory = new InventoryScript();
    [SerializeField] InventorySlot[] playerInventory;
    public string npcShopperTag;
    public GameObject npcShopper;
    // Use this for initialization
    void Start () {
        npcShopperTag = npcShopper.gameObject.tag;
    }
	
	// Update is called once per frame
	void Update () {
        //Clicou no NPC abre o shop de acordo com o npc
        switch (npcShopperTag)
        {
            case "Consumivel":
                //Abrir Loja Consumivel
                break;
            case "Equipamentos":
                //Abrir Loja Equipamento
                break;
            case "Armas":
                //Abrir Loja Armas
                break;
            default:
                break;
        }

    }
}
