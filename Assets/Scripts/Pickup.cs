using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;

    public float throwForce = 10;

    private bool hasPlayer = false;

    private bool beingCarried = false;

    public Rigidbody Rb;
    
    private bool Throw = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PileOStuff")
        {
            Throw = true;
        }
        hasPlayer = true;
        Debug.Log("Hit!");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PileOStuff")
        {
            Throw = false;
        }
        hasPlayer = false;
        Debug.Log("Not Hit!");
    }
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (beingCarried)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent = null;
                beingCarried = false;
                Rb.AddForce(player.forward * throwForce);
                Rb.isKinematic = false;

                Debug.Log("throw");

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && hasPlayer)
            {
                Rb.isKinematic = true;
                transform.parent = player;
                beingCarried = true;
            }
        }
    }
}
