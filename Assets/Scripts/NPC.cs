using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : Interactable {
    [SerializeField] Canvas canvasLoja;
    [SerializeField] GameObject loja;
    [SerializeField] Image janelaLoja;
    //[SerializeField] SpriteRenderer mira;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        //mira.enabled = true;
        AbrirLoja();
    }

    void AbrirLoja()
    {
        if(this.gameObject.name == "MercadorEquipamento")
        {
            Debug.Log("Abrindo Loja de Equipamento");
            canvasLoja.enabled = true;
           // loja = GameObject.Find("ViewPort(LojaEquipamento)");
            loja.SetActive(true);
        }
        else if (this.gameObject.name == "MercadorConsumivel")
        {
            Debug.Log("Abrindo Loja de Consumivel");
            canvasLoja.enabled = true;
           // loja = GameObject.Find("ViewPort(LojaConsumivel)");
            loja.SetActive(true);
        }
        else if(this.gameObject.name == "MercadorArma")
        {
            Debug.Log("Abrindo Loja de Arma");
            canvasLoja.enabled = true;
           // loja = GameObject.Find("ViewPort(LojaArma)");
            loja.SetActive(true);
        }
       
    }
}
