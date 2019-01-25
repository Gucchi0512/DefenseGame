using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour {
	[SerializeField]GameObject magic;
	[SerializeField]float speed=1.0f;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(magic.transform.position, Vector3.forward, speed);
	}
}
