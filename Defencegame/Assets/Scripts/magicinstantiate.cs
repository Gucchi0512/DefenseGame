﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicInstantiate : MonoBehaviour {
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
	}
}
