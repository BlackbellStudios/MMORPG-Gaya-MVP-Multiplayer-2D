using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Photon.MonoBehaviour {

    [SerializeField] protected float speed;
    private Animator myAnimator;
    protected Vector2 direction;

    private Rigidbody2D myRigidbody;
    [SerializeField] private Vector2 currentPosition;
    [SerializeField] private Vector2 destinationPosition;

    public bool IsMoving{
		get{ 
			return direction.x != 0 || direction.y != 0;
		}
	}

    public float Health { get; set; }
    public float Mana { get; set; }
    public float CurrentHealth { get; set; }
    public float CurrentMana { get; set; }

    protected virtual void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
    }

	protected virtual void Update () {
		HandleLayers ();
        if (destinationPosition.x == 0 && destinationPosition.y == 0)
        {
            return;
        }
        else {
            Move(currentPosition, destinationPosition);
        }
    }

	protected virtual void FixedUpdate(){

	}

    public void Move(Vector2 _current, Vector2 _target)
    {
        currentPosition = this.transform.position;
        _current = currentPosition;
        destinationPosition = _target;
        if (_current != _target)
        {
            transform.position = Vector2.MoveTowards(_current, _target, speed);
        }
        else
        {
            direction.x = 0;
            direction.y = 0;
        }
    }

	public void HandleLayers(){
		if (IsMoving) {
			Debug.Log ("Animação andando");
			ActivateLayer ("WalkLayer");

			myAnimator.SetFloat ("x", direction.x);
			myAnimator.SetFloat ("y", direction.y);
			} else {
			ActivateLayer ("IdleLayer");
		}
	
	}


    public void ActivateLayer(string layerName){
		for (int i = 0; i < myAnimator.layerCount; i++) {
			myAnimator.SetLayerWeight (i, 0);
		}
		myAnimator.SetLayerWeight (myAnimator.GetLayerIndex (layerName), 1);
	}

}
