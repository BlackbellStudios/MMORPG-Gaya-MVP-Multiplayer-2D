using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Player : Character
{
    public Interactable focus;
    [SerializeField] Transform target;
    [SerializeField] Transform PlayerTransform;

    [SerializeField] private Stats health;
    [SerializeField] private Stats mana;
    [SerializeField] private float currentHealthValue;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentManaValue;
    [SerializeField] private float maxMana;

    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private string MyClasse;

    [Header("Inventory")]
    [SerializeField] private Transform BagSlotsContainers;
    [SerializeField] private List<GameObject> Bags;
    PlayerInfo info;

    protected override void Start()
    {
        if (photonView.isMine)
        {
            this.gameObject.tag = "Player";
            PlayerTransform = this.transform;
            health = GameObject.Find("Health").GetComponent<Stats>();
            mana = GameObject.Find("Mana").GetComponent<Stats>();

            health.Initialize(currentHealthValue, maxHealth);
            mana.Initialize(currentManaValue, maxMana);

            //BagSlotsContainers = GameObject.Find("Bags").transform;
            MyClasse = GameObject.Find("GameBD").GetComponent<GameBD>().myClasse;
            //GetComponent<PhotonView>().RPC("SetInitial", PhotonTargets.AllBuffered, MyClasse);
            ExitGames.Client.Photon.Hashtable info = new ExitGames.Client.Photon.Hashtable();
            info.Add("MyClasse", MyClasse);
            PhotonNetwork.player.SetCustomProperties(info);
            base.Start();
        }
        Debug.Log("só pra saber q passei por aqui");
        MyClasse = photonView.owner.CustomProperties["MyClasse"].ToString();
        SetInitial(MyClasse);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (target != null)
        {
            endPos = target.transform.position;
            //FaceTarget();

        }

        if (photonView.isMine)
        {
            HandleTouch();
            base.Update();
            /*tranformado o metodo update da class Character em virtual, ela não executa mais
		pois e sobrscrita pelo metodo Update dessa classe(override).
		base.updete(); executa o metodo dentro da class character.
		*/
        }
    }



    protected override void FixedUpdate()
    {
        if (photonView.isMine)
        {
            base.FixedUpdate();
        }
    }

    private void GoesTo(Vector2 posEnd)
    {
        startPos = this.transform.position;
        Move(startPos, posEnd);
        direction = posEnd - startPos;
    }


    private void HandleTouch()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleRaycast(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);

        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                HandleRaycast(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                HandleRaycast(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandleRaycast(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Ended);
            }
        }
    }

    public void FollowTarget(Interactable newTarget)
    {
        if (newTarget != target)
        {
            newTarget.OnDefocused();
            target = newTarget.transform;

        }
        newTarget.OnFocused(transform);

    }

    /*
    public void StopFollowingTarget()
    {
        target = null;
        
    }
    */

    /*
    public void FaceTarget()
    {
        Vector3 direction= (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * 5f);
    }
    */


    private void HandleRaycast(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        Vector3 _touchPosition = touchPosition;
        RaycastHit2D hit = Physics2D.Raycast(_touchPosition, -Vector2.up);

        switch (touchPhase)
        {
            case TouchPhase.Began:
                Debug.Log("detectado" + hit.transform.tag);
                if (hit.collider.tag == "Canvas")
                {
                    Debug.Log("Gloria D'uxs");
                }
                else if (hit.collider.tag == "Ground")
                {
                    GoesTo(_touchPosition);
                    Debug.Log("Andando eu vou, andando agora eu vou, pararatimbum, pararatimbum");
                }
                else if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("Ai meu deus toquei um bicho");
                    GoesTo((Vector2)_touchPosition);
                    //hit.transform.GetComponent<Interactable>().OnFocused(this.transform);

                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
                else if (hit.collider.tag == "Item")
                {
                    Debug.Log("Money, baby");
                    GoesTo((Vector2)_touchPosition);
                    //hit.transform.GetComponent<Interactable>().OnFocused(this.transform);

                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
                else if (hit.collider.tag == "Vendedor")
                {
                    Debug.Log("WELCOME STRANGER");
                    GoesTo((Vector2)_touchPosition);
                    //hit.transform.GetComponent<Interactable>().OnFocused(this.transform);

                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if(interactable != null)
                    {
                        SetFocus(interactable);
                    }

                }
                else
                {
                    Debug.Log("vou fazer nada não tio!");
                }
                break;

            case TouchPhase.Stationary:
                Debug.Log("Marcando...");

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && photonView.isMine)
        {
            Obstacle o = collision.GetComponent<Obstacle>();

            o.FadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && photonView.isMine)
        {
            Obstacle o = collision.GetComponent<Obstacle>();

            o.FadeIn();
        }
    }


    public void SetInitial(string _MyClasse)
    {
        Animator _animator = GetComponent<Animator>();
        _animator.runtimeAnimatorController = Resources.Load("Controller/Charater/" + _MyClasse) as RuntimeAnimatorController;
    }

    void SetFocus(Interactable newfocus)
    {
        if (newfocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newfocus;
        }
        newfocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}

