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
        target = GameObject.FindGameObjectWithTag("Target");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 2;
        agent.destination=target.transform.position;
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update() {
        if(target!=null){
        dis = (transform.position - target.transform.position).sqrMagnitude;
            if (dis < 8.0f) {
                StartCoroutine("Attack");
            } 
        }
        
	}

    IEnumerator Attack(){
        animator.SetBool("walk", false);
        yield return new WaitForSeconds(2f);
        animator.SetBool("attack01", true);
        yield return null;
    }
}
