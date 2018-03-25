using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystatus : MonoBehaviour {
    public float hp;
    public float magicres;
    public float gunres;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0.0f) {
            Destroy(gameObject);
        }
	}
}
