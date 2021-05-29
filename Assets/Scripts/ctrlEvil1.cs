using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlEvil1 : MonoBehaviour {

    // Use this for initialization
    public GameObject BolaDeFogo;
    Collider2D c2dPercepcao;
    bool bCooldown = false;
    void Start () {
        StartCoroutine("Seligar"); 
	}
	
	// Update is called once per frame
	void Update () {


        

    }

    IEnumerator Seligar()
    {
        c2dPercepcao = Physics2D.OverlapCircle(transform.position, 5.02f);
        if (c2dPercepcao!=null && !bCooldown)
        {
            GameObject MinhaBola = Instantiate(BolaDeFogo, this.transform.position, this.transform.rotation);
            MinhaBola.SendMessage("SetarAlvo", string.Format("{0}|{1}|{2}", c2dPercepcao.transform.position.x, c2dPercepcao.transform.position.y,"Evil"));
            StartCoroutine("CoolDown");
        }
        yield return new WaitForSeconds(2);
        StartCoroutine("Seligar");
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        bCooldown = false;
    }
}
