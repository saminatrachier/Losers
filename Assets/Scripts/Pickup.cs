using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;

    public float throwForce = 10;

    public static bool hasPlayer = false;

    private bool beingCarried = false;

    public Rigidbody Rb;

    public static bool thrown = false;
    

    void OnCollisionEnter(Collision other)
    {
        
        hasPlayer = true;
        Debug.Log("Hit!");
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasPlayer = false;
            Debug.Log("Not Hit!");
        }
        
       
    }
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        EnemyHit.hitEnemy = true;
        thrown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Rb.velocity == new Vector3(0,0,0) && thrown == true)
        {
            player.gameObject.GetComponent<PlayerMove>().enabled = false;
            player.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
        }
        Vector3 destination = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (beingCarried)
        {
            if (Input.GetMouseButtonDown(0))
            {
                thrown = true;
                transform.parent = null;
                beingCarried = false;
                //sets bool to false
                EnemyHit.hitEnemy = false;
                Debug.Log("Miss");

                
                Rb.isKinematic = false;

                Rb.AddForce(player.forward * throwForce, ForceMode.Impulse);


            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && hasPlayer)
            {

                thrown = false;
               
                //if the enemyhit returns true, then run this
                if (EnemyHit.hitEnemy == true)
                {
                    thrown = false;
                    Rb.isKinematic = true;
                    transform.parent = player;
                    transform.localPosition = new Vector3(0,.5f,1);
                    beingCarried = true;
                }
               
            }
            
        }
    }
}
