using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManage : MonoBehaviour {
    Transform target;
    Animator animator;
    NavMeshAgent agent;
    Status status;
    Status targetStatus;
    [SerializeField]private string attackanimate;

    SphereCollider sphereCollider;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        targetStatus=target.GetComponent<Status>();
        animator = GetComponent<Animator>();
        status=GetComponent<Status>();
        agent = GetComponent<NavMeshAgent>();
        sphereCollider=GetComponentInChildren<SphereCollider>();
        agent.speed = status.speed;
        sphereCollider.enabled=false;
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update() {
        if(target!=null){
            agent.destination=target.position;
        }else{
            animator.SetBool("walk", false);
        }
        
	}
    void OnTriggerStay(Collider col){
        if(col.tag=="Target"){
            agent.isStopped=true;
            if(animator.GetBool("walk")) animator.SetBool("walk", false); 
            animator.SetBool(attackanimate, true);
        }
    }
    void AttackStart(){
        sphereCollider.enabled=true;
    }

    void AttackEnd(){
        sphereCollider.enabled=false;
    }
}
