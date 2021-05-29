using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    private string nome;
    [SerializeField]
    private string tipo;
    [SerializeField]
    private int Value;

    void Start()
    {
        nome = "Bolsa moedas";
        tipo = "Prata";
        Value = 10;

    }

    public void Collect() {
        Debug.Log("Capiroto da peste arretada você coletou: " + nome + " do Tipo: " + tipo + " e valor " + Value);

        Destroy(this.gameObject);
    }
}
