using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gobrinmove : MonoBehaviour {
    public GameObject target;
    public float dis;
    bool arrived=false;
    Animator animator;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        agent.destination = target.transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        dis = (transform.position - target.transform.position).sqrMagnitude;
        if (dis > 8.0f && !arrived) {
            animator.SetBool("walk", true);
        }else if (!arrived) {
            animator.SetBool("walk", false);
            animator.SetBool("attack01", true);
            arrived = true;
        } 
        
	}
}
