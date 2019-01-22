using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManage : MonoBehaviour {
    private Transform target;
    Animator animator;
    NavMeshAgent agent;
    Status status;
    Status targetStatus;
    [SerializeField]private string attackanimate;
    [SerializeField]private float attackDelay;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        targetStatus=target.GetComponent<Status>();
        animator = GetComponent<Animator>();
        status=GetComponent<Status>();
        agent = GetComponent<NavMeshAgent>();
        Vector3 targetPosOnGround = target.position;
        targetPosOnGround.y=0;
        agent.speed = 2;
        agent.stoppingDistance=2;
        agent.SetDestination(targetPosOnGround);
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update() {
        if(target!=null){
            if(agent.remainingDistance<agent.stoppingDistance){
                agent.isStopped=true;
                if(animator.GetBool("walk")) animator.SetBool("walk", false); 
                StartCoroutine("Attack");
            }else{
			    if(!animator.GetBool("walk")) animator.SetBool("walk", true);
            }
        }else{
            animator.SetBool("walk", false);
        }
        
	}
    
    IEnumerator Attack(){
        while(status.hp>0){
            yield return new WaitForSeconds(attackDelay);
            animator.SetBool(attackanimate, true);
            yield return new WaitForSeconds(attackDelay);
            animator.SetBool(attackanimate, false);
            targetStatus.hp-=status.power;
            yield return null;
        }
    }
}
