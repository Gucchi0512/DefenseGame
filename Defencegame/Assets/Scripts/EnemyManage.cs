using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManage : MonoBehaviour {
    [SerializeField]private Transform target;
    private float dis;
    bool arrived=false;
    Animator animator;
    NavMeshAgent agent;
    Status status;
    Status targetStatus;
    [SerializeField]private string attackanimate;
    [SerializeField]private float power;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        targetStatus=target.GetComponent<Status>();
        animator = GetComponent<Animator>();
        status=GetComponent<Status>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update() {
        if(target!=null){
            //agent.SetDestination(target.position);
            agent.destination=target.position;
            Debug.Log(target.transform.position+" "+agent.destination);
			if(!animator.GetBool("walk")) animator.SetBool("walk", true);
        }else{
            animator.SetBool("walk", false);
        }
        
	}
    void OnTriggerStay(Collider col){
        if(col.tag=="Target"){
            if(animator.GetBool("walk")) animator.SetBool("walk", false); 
            StartCoroutine("Attack");
        }
    }
    IEnumerator Attack(){
        while(status.hp>0){
            yield return new WaitForSeconds(2f);
            animator.SetBool(attackanimate, true);
            yield return new WaitForSeconds(2f);
            animator.SetBool(attackanimate, false);
            targetStatus.hp-=power;
            yield return null;
        }
    }
}
