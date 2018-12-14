using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gobrinmove : MonoBehaviour {
    private GameObject target;
    public float dis;
    bool arrived=false;
    Animator animator;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        animator = GetComponent<Animator>();
        target=GameObject.Find("Crystal");
    }

    // Update is called once per frame
    void Update() {
        dis = (transform.position - target.transform.position).sqrMagnitude;
        agent.SetDestination(target.transform.position);
        if (dis > 8.0f && !arrived) {
            animator.SetBool("walk", true);
        }else if (!arrived) {
            animator.SetBool("walk", false);
            animator.SetBool("attack01", true);
            arrived = true;
        } 
        
	}
}
