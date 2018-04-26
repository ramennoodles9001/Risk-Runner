using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool allowInput=true;
	private CharacterController characterController;
	private Vector3 moveDirection;
	private Transform camera;
	private float minAngle=-70, maxAngle=70, rotationX,rotationY,rotationZ,sensitivity_x=1f, recoil, compensation, testVel = 0.0f, gravity=0.4f, fallSpeed = 0f, minFallSpeed=-2f, jumpSpeed;
	public float modifiedMoveSpeed=1, baseMoveSpeed=0.5f;
	// Use this for initialization
	void Start () {
		modifiedMoveSpeed = 1;
		characterController = GetComponent<CharacterController>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		lockCursor();
	}
	
	// Update is called once per frame
	void Update () {
		//Move x y axis

		if(Input.GetKeyDown(KeyCode.Escape)){
			unlockCursor();
		}
		if(Input.GetMouseButtonDown(0)){
			lockCursor();
		}
		if(!characterController.isGrounded){
			if(fallSpeed>minFallSpeed)
			fallSpeed = -(0.5f*Mathf.Sqrt(-fallSpeed)+gravity);
		}else{
			fallSpeed = 0;
			
		}
		if(Input.GetKey(KeyCode.Space) && characterController.isGrounded){
			jumpSpeed=Mathf.Lerp(jumpSpeed,5,0.6f);
		}
		if(jumpSpeed>0){
			jumpSpeed = Mathf.Lerp(jumpSpeed,0,0.1f);
		}
		//Set gravity
		
		if(allowInput){
			moveDirection = new Vector3(Input.GetAxis("Horizontal")*modifiedMoveSpeed,jumpSpeed+fallSpeed,Input.GetAxis("Vertical")*modifiedMoveSpeed);
			rotationX += Input.GetAxis("Mouse X") * sensitivity_x;
            rotationY += (Input.GetAxis("Mouse Y") * sensitivity_x) + recoil + compensation;
            transform.rotation = Quaternion.Euler(0, rotationX, 0);
            camera.rotation = Quaternion.Euler(-rotationY, camera.eulerAngles.y, rotationZ);
		}
		//Gravity
		
		//Set forward direction
		moveDirection = transform.TransformDirection(moveDirection);
		characterController.Move(moveDirection*Time.deltaTime*baseMoveSpeed);

		//Rotation:
		//Smooths past max angle camera looking
		if (rotationY > maxAngle)
            rotationY = Mathf.SmoothDamp(rotationY,maxAngle,ref testVel,0.05f);
        if (rotationY < minAngle)
            rotationY  = Mathf.SmoothDamp(rotationY,minAngle,ref testVel, 0.05f);;
        
		transform.Rotate(0,Input.GetAxis("Mouse X"),0);
		
	}

	public void lockCursor()
    {
        //Sets cursor in game invisible and locked in the middle.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void unlockCursor(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
