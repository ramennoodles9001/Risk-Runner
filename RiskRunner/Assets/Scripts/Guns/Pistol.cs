﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pistol : Gun {

	// Use this for initialization

	
	// Update is called once per frame

	protected override void Shoot(){
		if(magazine > 0 && canShoot){
			RaycastHit hit;
			//Shoot out ray to see if something is hit
			//Debug.DrawRay(playerCam.position,playerCam.forward*20f,Color.black,20f);
			if(Physics.Raycast(playerCam.position, playerCam.forward*range, out hit)){
				//Debug.Log(hit.transform.name);

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
