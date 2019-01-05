using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrystalColor : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	public void colorchange(float hp){
		var mat = GetComponent<Renderer>().material;
		if(hp<=5000f&&hp>1000f){
			mat.SetColor("_Color", Color.yellow);
			mat.SetColor("_EmissonColor", Color.yellow);
		}else if(hp<=1000f){
			mat.SetColor("_Color", Color.red);
			mat.SetColor("_EmissionColor", Color.red);		
		}
	}
}
