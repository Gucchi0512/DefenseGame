using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gobrinmove : MonoBehaviour {
    private GameObject target;
    private float dis;
    bool arrived=false;
    Animator animator;
    NavMeshAgent agent;
    Status status;
    Status targetStatus;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target");
        targetStatus=target.GetComponent<Status>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        agent.destination=target.transform.position;
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);
        status=GetComponent<Status>();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(agent.remainingDistance+" "+agent.stoppingDistance);
        if(target!=null){
            if (agent.remainingDistance < agent.stoppingDistance) {
                if(animator.GetBool("walk")) animator.SetBool("walk", false); 
                StartCoroutine("Attack");
            } else{
				if(!animator.GetBool("walk")) animator.SetBool("walk", true);
			}
        }else{
            animator.SetBool("walk", false);
        }
        
	}

    IEnumerator Attack(){
        while(status.hp>0||agent.remainingDistance>=agent.stoppingDistance){
            yield return new WaitForSeconds(2f);
            animator.SetBool("attack01", true);
            yield return new WaitForSeconds(2f);
            animator.SetBool("attack01", false);
            targetStatus.hp-=5f;
            yield return null;
        }
    }
}
