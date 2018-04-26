using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public int magazine, magazineSize, ammo, maxAmmo, range=1, rps=1;
	public bool canShoot;
	// Use this for initialization 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reload(){
		if (ammo>0){
			if(ammo>=magazineSize){
				ammo-=magazineSize;
				magazine = magazineSize;
			}else{
				int x = ammo;
				ammo = 0;
				magazine = x;
			}
		}
	}

	public void Shoot(){

	}
}
