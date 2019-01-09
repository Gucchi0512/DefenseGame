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
		rayMask=LayerMask.GetMask("Movable");
		laser=GetComponent<LineRenderer>();
		reticle=Instantiate(reticlePrefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public RaycastHit ShowLaser(){
		ray.origin=transform.position;
		ray.direction=transform.forward;
		laser.enabled=true;
		laser.SetPosition(0,transform.position);
		if(Physics.Raycast(ray, out hit, range, rayMask)){
			laser.SetPosition(1, hit.point);
			reticle.SetActive(true);
			reticle.transform.position=hit.point+reticleOffset;
		}else{
			laser.SetPosition(1, ray.origin+ray.direction*range);
			reticle.SetActive(false);
		}
		return hit;
	}
	public void DeleteLaser(){
		laser.enabled=false;
		reticle.SetActive(false);
	}
}
