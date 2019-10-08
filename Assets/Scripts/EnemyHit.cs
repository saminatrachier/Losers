using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Rigidbody EnemyRb;

    public Transform Ball;

    public AudioClip oof;
    private AudioSource audio;

    public Transform securityPrefab;
    private int securityCount =0;
 

    //bool to see if the ball hits an enemy
   static public bool hitEnemy = false;
    
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ball")
        {

            //for some reason they dont both work? need a way to fix this
            if (gameObject.tag == "Enemy")
            {
                GetComponent<EnemyMove>().enabled = false;

            }

            if (gameObject.tag == "Security")
            {
                GetComponent<FollowPlayer>().enabled = false;
                //checks how many security are out and spawns another on hit
                if (securityCount <= 10)
                {
                    Vector3 randomPosition = new Vector3(Random.Range(0f,85f),1f, Random.Range(-14f,14f));
                    Instantiate(securityPrefab, randomPosition, Quaternion.Euler(0, Random.Range(0f,360),0));
                    GetComponent<FollowPlayer>().enabled = true;

                    //increment the counter
                    securityCount++;
                }


            }

            else if (gameObject.tag == "Enemy2")
            {
                GetComponent<EnemyMove2>().enabled = false;

            }

            //play audio clip (oof)
            audio.PlayOneShot(oof, .5f);
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
        
        //oof audio
       audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
