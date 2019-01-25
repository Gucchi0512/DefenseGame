using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Status : MonoBehaviour {
	[SerializeField]private float hp;
	public float speed;
	public float magicres;
	public float power;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.tag=="enemy"&&this.hp<=0){
			GetComponent<NavMeshAgent>().isStopped=true;
			AnimatorClipInfo clipInfo = animator.GetCurrentAnimatorClipInfo(0)[0];
			animator.SetBool(clipInfo.clip.name, false);
			animator.SetBool("dead", true);
			StartCoroutine("DeadEnemy");
		}else if(this.gameObject.tag=="Target"){
			//Debug.Log(hp);
			var parent = transform.root.gameObject;
			parent.GetComponentInChildren<CrystalColor>().colorchange(hp);
		}
	}

	public void Damage(float hitpower){
		this.hp-=hitpower;
	}
	private IEnumerator DeadEnemy(){
		yield return new WaitForSeconds(3f);
		Destroy(this.gameObject);
	}
}
