using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlControleJogo : MonoBehaviour {
    public GameObject goAlvo;
	// Use this for initialization
	void Start () {
        StartCoroutine("VerificarAlvo");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator VerificarAlvo()
    {
        GameObject go = GameObject.Find("Alvo");
        
        if (go==null)
        {
            go = GameObject.Find("Alvo(Clone)");
            if (go==null)
                Instantiate(goAlvo);
            
        }
        yield return new WaitForSeconds(2);
        StartCoroutine("VerificarAlvo");
    }
    
}
