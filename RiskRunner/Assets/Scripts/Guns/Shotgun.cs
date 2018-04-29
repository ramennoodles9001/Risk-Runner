using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun {
	[SerializeField]
	protected int pellets;
	// Use this for initialization

	protected override void Shoot(){
		
		if(magazine > 0 && canShoot){
			RaycastHit hit;
			//Shoot out ray to see if something is hit
			Debug.DrawRay(playerCam.position,playerCam.forward*range,Color.black,20f);
			for(int i =0; i<pellets;i++){
				if(Physics.Raycast(playerCam.position, playerCam.forward*range, out hit)){
				//Debug.Log(hit.transform.name);
					Debug.Log("Shot");
				}
			}
			
			magazine-=1;
			canShoot = false;
			Recoil();
			Invoke("ableToShoot",1/rps);
		}
	}

	public void ableToShoot(){
		canShoot = true;
	}

	protected override void Recoil(){
		playerMovement.Recoil(recoil);
	}
}
