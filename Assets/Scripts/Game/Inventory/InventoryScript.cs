using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

    public static InventoryScript instance;
    public List<Item> items = new List<Item>();
    public int space = 20;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;



    //public Bolsa[] itens;

    //private static InventoryScript instance;

    /*
public static InventoryScript MyInstance {
    get {
        if (instance == true) {
            instance = FindObjectOfType<InventoryScript> ();
        }
        return instance;
    }
}
*/

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Sem espaço");
            return false; //falhou em pegar o item
        }
        items.Add(item);
        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); //atualiza a ui do inventario
           
        }
        
        return true; //pegou o item

    }


    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke(); //atualiza a ui do inventario
        }

    }

    //for debugging
    //[SerializeField] private Bag[] newBag;

    private void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("Mais de uma instancia de inventário detectada");
            return;
        }
        instance = this;

        /*
        //busca as bolsas desse player
        GameBD gameBD = GameObject.Find("GameBD").GetComponent<GameBD>();
        itens = JsonHelper.FromJson<Bolsa>("{\"values\":" +gameBD.myBolsa+"}");
        Debug.Log("{\"Items\":" + gameBD.myBolsa + "}");
        Debug.Log(itens);

        //Bag bag = Instantiate(newBag[0]);
        //bag.Initialize (16);
        //bag.Use ();
        */
    }
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
