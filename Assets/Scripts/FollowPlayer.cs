using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = player.position - transform.position;
        RaycastHit hit;
        Ray followRay = new Ray(transform.position, transform.forward);
        float maxRayDistance = 1.5f;
        Debug.DrawRay(followRay.origin, followRay.direction * maxRayDistance, Color.magenta);
        if (Physics.Raycast(followRay, out hit, maxRayDistance))
        {
            if  (hit.collider.gameObject.CompareTag("Enemy"))
            {
                
            }
            else
            {
                transform.forward = Vector3.Lerp( transform.forward, moveDir, Speed * Time.deltaTime );
                transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
            }
            
            
        }
        else
        {
            transform.forward = Vector3.Lerp( transform.forward, moveDir, Speed * Time.deltaTime );
            transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }
        
        }
    }

