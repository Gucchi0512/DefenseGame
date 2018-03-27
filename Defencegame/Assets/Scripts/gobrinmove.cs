using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gobrinmove : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = 1;
        agent.destination = target.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
