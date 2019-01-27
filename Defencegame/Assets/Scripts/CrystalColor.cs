using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrystalColor : MonoBehaviour {
	Color orange = new Color(1.0f, 165/255f, 0.0f);
	// Use this for initialization
	void Start () {

	}
	
	public void colorchange(float hp){
		var mat = GetComponent<Renderer>().material;
		if(hp<=350&&hp>175){
			mat.SetColor("_Color", Color.yellow);
			mat.SetColor("_EmissionColor", Color.yellow);
		}else if(hp<=175&&hp>0){
			mat.SetColor("_Color", orange);
			mat.SetColor("_EmissionColor", orange);		
		}else if(hp<=0){
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayingManage>().isPlaying=false;
			mat.SetColor("_Color", Color.red);
			mat.SetColor("_EmissionColor", Color.red);
		}
	}
}
