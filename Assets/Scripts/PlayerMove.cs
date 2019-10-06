using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 10;



    Vector3 inputVector;

    private float upDownRotation;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); //corresponds to W/S or Up/Down on a Keyboard, -1 for down +1 for up
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right on Keyboard, -1 is left, +1 is right
		
        inputVector = transform.forward * vertical * moveSpeed; //forward/back direction
        inputVector += transform.right * horizontal * moveSpeed; //left/right direction
    }
    void FixedUpdate() //all physics code should go in FixedUpdate!!!
    {
        //apply our forces to move the object around
        GetComponent<Rigidbody>().velocity = new Vector3(inputVector.x,GetComponent<Rigidbody>().velocity.y,inputVector.z); //no need for Time.deltatime, already fixed framerate

    }
    

}
