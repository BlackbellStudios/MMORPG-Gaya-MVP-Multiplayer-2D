using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {
    
	[SerializeField] private GameObject slotPrefab;
    public void Start()
    {
        if(gameObject.tag == "content")
        {
            AddSlots(20);
        }
        else if(gameObject.tag == "bag")
        {
            AddSlots(5);
        }
       
    }
    public void AddSlots(int slotCount){
        
		for (int i = 0; i < slotCount; i++) {
			Instantiate (slotPrefab, transform);
		}
	}
}
