using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : Character {
    public float lookRadius = 100f;
    Transform target;
    CharacterCombat combat;
    Transform enemy;
    float distance;
    //float speed = 8.0f;

    
    [SerializeField]public bool agressivo = false;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    Animator enemyAnim;
    // Use this for initialization
    protected override void Start()
    {
        combat = GetComponent<CharacterCombat>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        InvokeRepeating("GoesTo", 3, 3);
        InvokeRepeating("Idle", 0, 4);
        enemyAnim = GetComponent<Animator>();
        base.Start();
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        if (target == null)
        {
            try
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch (System.Exception)
            {
                return;
            }
        }
        
        distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            //se o inimigo for agressivo ele irá se mover para o player assim que entrar no alcance
            //if (agressivo == true)
           // {
                //Stop();
                //se movimenta até proximo do target
                if ((Vector2.Distance(transform.position, target.position)) > 10)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    //rotaciona olhando pro target
                }


                if (distance <= 10)
                {
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                    if (targetStats != null)
                    {
                        //attack the target
                        combat.Attack(targetStats);
                    }

                    //face the target
                    //FaceTarget();
                }
            //}
        }
        base.Update();
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    //Métodos de movimentação do inimigo
    private void GoesTo()
    {
        speed = 8.0f;
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

    private void Idle()
    {
        //colocar animação de idle
        speed = 0.0f;
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

}
