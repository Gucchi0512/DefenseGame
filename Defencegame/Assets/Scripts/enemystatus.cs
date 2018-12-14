using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystatus : MonoBehaviour {
    public float hp;
    public float magicres;
    public float gunres;
    Animator animator;
    AnimatorStateInfo anistate;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0.0f) {
            animator.SetBool("dead", true);
            anistate = animator.GetCurrentAnimatorStateInfo(0);
            if (anistate.normalizedTime > 1.0f) {
                Destroy(gameObject);
            }
        }
	}

}
