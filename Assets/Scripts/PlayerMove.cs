using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 10;

    public GameObject MainCamera;

    public float lookSpeed = 300f;

    public Vector3 inputVector;

    private float upDownRotation;

    public static bool Tackled = false;
    
    
    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor in the center of the screen
        Cursor.visible = false; //hides the cursor just to be safe
        Tackled = false;
    }
    
    //security collision detection
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Security")
        {
            Debug.Log("Tackled");
            Tackled = true;
           
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            gameObject.GetComponent<PlayerMove>().enabled = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        //mouse look
        float mouseX = Input.GetAxis("Mouse X")* lookSpeed * Time.deltaTime; //mouseX = horizontal mouseDelta
        float mouseY = Input.GetAxis("Mouse Y")* lookSpeed * Time.deltaTime; //mouseY = vertical mouseDelta
		
        //rotate capsule left/right, but rotate camera up/down
        transform.Rotate(0f, mouseX, 0f);
//		Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f);
		
//		BETTER MOUSE LOOK: Add mouseInput to upDOwnRotation AND clamp upDownRotation
        upDownRotation -= mouseY;
        upDownRotation = Mathf.Clamp(upDownRotation, -80, 80);

        //solution: after applying rotations, un-roll the camera
        Camera.main.transform.localEulerAngles = new Vector3(upDownRotation,0f, 0f);
		
        //BETTER MOUSE LOOK: Lock and hide the mouse cursor
        //if (Input.GetMouseButtonDown(0)) //0 = left click
        //{
           
      //  }

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
