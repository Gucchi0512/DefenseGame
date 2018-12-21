using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasermanage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

 	void OnParticleCollision(GameObject other){
		 if(other.gameObject.tag==("enemy")){
		 	other.GetComponent<Status>().hp-=3.0f;
		 }
		 Destroy(gameObject);
	}
}
