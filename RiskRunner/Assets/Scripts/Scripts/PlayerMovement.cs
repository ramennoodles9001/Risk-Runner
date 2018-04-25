using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool allowInput=true;
	private CharacterController characterController;
	private Vector3 moveDirection;
	
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		moveSpeed = 0;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(allowInput){
			moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,0,Input.GetAxis("Vertical")*moveSpeed);
		}
		moveDirection = transform.TransformDirection(transform.forward);
		characterController.Move(moveDirection);
	}
}
