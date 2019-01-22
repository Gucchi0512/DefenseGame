﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrystalColor : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	public void colorchange(float hp){
		var mat = GetComponent<Renderer>().material;
		if(hp<=(hp/2)&&hp>(hp/4)){
			mat.SetColor("_Color", Color.yellow);
			mat.SetColor("_EmissonColor", Color.yellow);
		}else if(hp<=(hp/4)){
			mat.SetColor("_Color", Color.red);
			mat.SetColor("_EmissionColor", Color.red);		
		}
	}
}