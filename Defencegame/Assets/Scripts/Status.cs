using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Status : MonoBehaviour {
	public float hp;
	public float magicres;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.tag=="enemy"&&this.hp<=0){
			GetComponent<NavMeshAgent>().Stop();
			AnimatorClipInfo clipInfo = animator.GetCurrentAnimatorClipInfo(0)[0];
			animator.SetBool(clipInfo.clip.name, false);
			animator.SetBool("dead", true);
			StartCoroutine("Deadenemy");
		}else if(this.gameObject.tag=="Target"){
			var parent = transform.root.gameObject;
			parent.GetComponentInChildren<CrystalColor>().colorchange(hp);
		}
	}
	private IEnumerator Deadenemy(){
		yield return new WaitForSeconds(3f);
		Destroy(this.gameObject);
	}
}
