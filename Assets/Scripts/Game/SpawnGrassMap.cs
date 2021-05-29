using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrassMap : MonoBehaviour
{
    private float spawnTime = 5f;
    [SerializeField] private bool coldown = false;
    [SerializeField] private int qtdTotalSlimeVerde = 30;
    //[SerializeField] private int qtdTotalSlimeVermelho = 20;
    //[SerializeField] private int qtdTotalSlimeAzul = 10;

    [SerializeField] private int qtdAtualSlimeVerde = 0;
    //[SerializeField] private int qtdAtualSlimeVermelho = 0;
    //[SerializeField] private int qtdAtualSlimeAzul = 0;
    [SerializeField] private GameObject slimeVerde;
    [SerializeField] private List<GameObject> LSlime = new List<GameObject>();
    //GameObject slimeVermelho = new GameObject();
    // GameObject slimeAzul = new GameObject();

    // Use this for initialization
    void Start()
    {
        
        InvokeRepeating("SpawnSlime", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnSlime()
    {
        coldown = false;
        if (LSlime.Count < qtdTotalSlimeVerde && coldown == false)
        {
            Vector2 pos = new Vector2(Random.Range(150, 500), Random.Range(900, 500));
            GameObject go = new GameObject();
            go = Instantiate(slimeVerde, pos, Quaternion.identity);
            coldown = true;
            go.name = "Slime";
            LSlime.Add(go);
            qtdAtualSlimeVerde++;
        }
    }
}
