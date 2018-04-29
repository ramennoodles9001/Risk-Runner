using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour {
	[SerializeField]
	protected int magazine, magazineSize, ammo, maxAmmo, range=1, rps=1;
	protected bool canShoot=true;
	[SerializeField]
	protected float recoil;

	protected Transform playerCam;
	protected PlayerMovement playerMovement;
	// Use this for initialization 
	void Start () {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		playerCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Shoot();
		}
	}

	public void Reload(){
		if (ammo>0){
			if(ammo>=magazineSize){
				ammo-=magazineSize;
				magazine = magazineSize;
				Recoil();
			}else{
				int x = ammo;
				ammo = 0;
				magazine = x;
			}
		}
	}

	protected virtual void Shoot(){

	}

	protected virtual void Recoil(){

	}
}
