using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {
	private Transform camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		rps = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Shoot();
		}
		
	}

	public void Shoot(){
		if(magazine > 0 && canShoot){
			RaycastHit hit;
			//Shoot out ray to see if something is hit
			Debug.DrawRay(camera.position,camera.forward*20f,Color.black,20f);
			if(Physics.Raycast(camera.position, camera.forward*range, out hit)){
				Debug.Log(hit.transform.name);
			}
			magazine-=1;
			canShoot = false;
			Invoke("ableToShoot",rps);
		}
	}

	public void ableToShoot(){
		canShoot = true;
	}
}
