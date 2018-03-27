using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystatus : MonoBehaviour {
    public float hp;
    public float magicres;
    public float gunres;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0.0f) {
            animator.SetBool("dead", true);    
        }
	}
}
