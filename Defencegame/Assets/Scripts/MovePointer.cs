using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointer: MonoBehaviour {
	[SerializeField]private float range = 100f;
	[SerializeField]private GameObject reticlePrefab;
	[SerializeField]private Vector3 reticleOffset;

	private GameObject reticle;
	private int rayMask;

	LineRenderer laser;
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		rayMask=LayerMask.GetMask("movable");
		laser=GetComponent<LineRenderer>();
		reticle=Instantiate(reticlePrefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
