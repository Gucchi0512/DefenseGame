using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TrollMove : MonoBehaviour {

	[SerializeField]private GameObject target;
	Animator animator;
	NavMeshAgent agent;
	Status status;
	Status targetStatus;
	// Use this for initialization
	void Start () {
		agent=GetComponent<NavMeshAgent>();
		animator=GetComponent<Animator>();
		status=GetComponent<Status>();
		target=GameObject.FindGameObjectWithTag("Target");
		targetStatus=target.GetComponent<Status>();
		agent.destination=target.transform.position;
		agent.speed=5;
		animator.SetBool("walk", true);
	}
	
	// Update is called once per frame
	void Update () {
		if(target!=null){
			if(agent.remainingDistance<=agent.stoppingDistance){
				if(animator.GetBool("walk")) animator.SetBool("walk", false);
				StartCoroutine("Attack");
			}
		}else{
			animator.SetBool("walk", false);
		}
	}

	IEnumerator Attack(){
		while(status.hp>0||agent.remainingDistance>agent.stoppingDistance){
			yield return new WaitForSecondsRealtime(5f);
			animator.SetBool("attack03", true);
			yield return new WaitForSecondsRealtime(2f);
			targetStatus.hp-=10f;
			yield return null;
		}
	}
}
