using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radious = 10f;
    [SerializeField] bool isFocus = false;
    [SerializeField] bool hasInteracted = false;
    [SerializeField] Transform player;
    [SerializeField] SpriteRenderer mira;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radious)
            {
                Debug.Log("interact");
                hasInteracted = true;
                Interact();
            }
        }

    }

    public virtual void Interact()
    {
        //Debug.Log("Interagindo com: " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        Debug.Log(playerTransform);
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        mira.enabled = true;

    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        mira.enabled = false;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radious);
    }


}
