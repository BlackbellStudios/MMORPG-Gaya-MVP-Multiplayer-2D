using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
   
    PlayerManager playerManager;
    CharacterStats myStats;

    [SerializeField] private Stats health;
    [SerializeField] private float currentHealthValue;
    [SerializeField] private float maxHealth;

    
    //[SerializeField]SpriteRenderer mira;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        maxHealth = myStats.maxHealth;
        currentHealthValue = myStats.currentHealth;
        health = GameObject.Find("HealthBar").GetComponent<Stats>();
        health.Initialize(currentHealthValue, maxHealth);
        
    }

  

    public override void Interact()
    {
        base.Interact();
        //this.mira.enabled = true;
        //attack the enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);

        }
    }









}
    /*
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    */

    
    
    
    
    
    
    
    
    
    
    
    /*variaveis de estado do slime
    [SerializeField] private bool agressivo = false;
    [SerializeField] private bool tomouDano = false;
    [SerializeField] private Animator slimeAnim;
    //[SerializeField] private GameObject alvoAtual = new GameObject();

    //variaveis de drop
    [SerializeField] List<GameObject> DropList = new List<GameObject>();
    [SerializeField] GameObject[] loot;

    public EnemyController control;
    public Character character;
    // Use this for initialization

    protected override void Start()
    {
        slimeAnim = GetComponent<Animator>();
        //Status Iniciais do Slime
        InvokeRepeating("GoesTo",3,3);
        InvokeRepeating("Idle", 0, 4);
        base.Start();
    }

    




    /* Update is called once per frame
    protected override void Update()
    {
        if (agressivo == true)
        {
            Ataque();
            Stop();
        }

        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Obstacle o = collision.GetComponent<Obstacle>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Obstacle o = collision.GetComponent<Obstacle>();
        }
    }


    private void GoesTo()
    {
        speed = 0.3f;
        if (startPos == endPos)
        {
            float x = Random.Range(-460f, 650f);
            float y = Random.Range(900f, 1500f);
            Vector2 vector = new Vector2(x, y);
            endPos = vector;
        }
        else
        {
            startPos = transform.position;
            //endPos = posEnd;
            Move(startPos, endPos);
            direction = endPos - startPos;
        }
        
    }

    private void Stop()
    {
        startPos = transform.position;
       // endPos = alvoAtual.transform.position;
        Move(startPos, endPos);
        direction = endPos - startPos;
    }

    /*Metodo que coloca o slime no modo agressivo para atacar o jogador
    private void Ataque()
    {
        //transform.LookAt(alvoAtual.transform);
        regenMana();
        //Se o slime tomar dano ele mostra a animação "tomando dano"
        if (tomouDano == true)
        {
            danoRecebido();
        }
        //Slime ataca assim que receber um dano
        slimeAnim.SetTrigger("ataque");
        coldownAtaque();
        //Após atacar retorna pra idle até o coldown do proximo ataque
        slimeAnim.SetTrigger("idle");
        //Após 5 segundos no modo agressivo o slime solta seu poder especial
        AtaqueEspecial();

      
    }
    */

    /*
    private void danoRecebido()
    {
        //CurrentHealth -= danoJogador;
        slimeAnim.SetTrigger("takingdamage");
    }
    IEnumerator regenMana()
    {
        yield return new WaitForSeconds(10);
        if (this.CurrentMana <= 40)
        {
            this.CurrentMana += 2;
        }
    }

    IEnumerator coldownAtaque()
    {
        yield return new WaitForSeconds(2);
        slimeAnim.SetTrigger("idle");
    }


    IEnumerator AtaqueEspecial()
    {
        yield return new WaitForSeconds(5);
        slimeAnim.SetTrigger("ataquespecial");
        this.CurrentMana -= 10;
    }

    private void Idle()
    {
        slimeAnim.SetBool("idle", true);
        speed = 0.0f;
    }


    private void Loot()
    {
        int randomItem = Random.Range(1, loot.Length+1);

        Instantiate(loot[randomItem], transform);
    }
    */
