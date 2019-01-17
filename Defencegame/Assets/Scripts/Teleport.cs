using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	[SerializeField]GameObject player;
	[SerializeField]MovePointer pointer;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger)){
			hit=pointer.ShowLaser();
		}else{
			pointer.DeleteLaser();
		}
		if(OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)){
			Move(hit);
		}
	}

	private void Move(RaycastHit hit){
		player.transform.position=hit.point;
	}
}
