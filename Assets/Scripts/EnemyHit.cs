using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Rigidbody EnemyRb;

    public Transform Ball;

    //bool to see if the ball hits an enemy
   static public bool hitEnemy = false;
    
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ball")
        {

            //for some reason they dont both work? need a way to fix this
            GetComponent<EnemyMove>().enabled = false;
            //GetComponent <EnemyMove2>().enabled = false;

            EnemyRb.freezeRotation = false;
            //unfreezes the enemys rotations upon hit
            
            
            EnemyRb.AddForce((transform.position - Ball.position)*-100);
            //if the ball hits an enemy then it returns true
            hitEnemy = true;
            Pickup.hasPlayer = true;
            Debug.Log("Hit that fucker");

            

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
