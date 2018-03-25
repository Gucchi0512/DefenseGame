﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicmotion : MonoBehaviour {
    float chargetime = 0.0f;
    float speed = 300.0f;
    float power = 25.0f;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera");    	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)&&chargetime<=5.0f) {
            chargetime += 0.05f;
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
        if (Input.GetMouseButtonUp(0)) {
            Vector3 force;
            force = player.transform.forward * speed;
            GetComponent<Rigidbody>().AddForce(force);
        }
	}

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.tag);
        Destroy(gameObject);
        if (collision.gameObject.tag == "enemy") {
            Enemystatus hitenemy = collision.gameObject.GetComponent<Enemystatus>();
            hitenemy.hp -= (power + chargetime) - hitenemy.magicres;
        } 
    }
}