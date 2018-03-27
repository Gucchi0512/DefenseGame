using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public ParticleSystem.MainModule par;
    // Use this for initialization
    void Start () {
        par = GetComponent<ParticleSystem>().main;
    }
	
	// Update is called once per frame
	public void ColorChange(string color) {
        Debug.Log("called");
        switch (color) {
            case "red": {
                par.startColor = Color.red;
                break;
            }
            case "blue": {
                par.startColor = Color.blue;
                break;
            }
            case "yellow": {
                par.startColor = Color.yellow;
                break;
            }
            case "green": {
                par.startColor = Color.green;
                break;
            }
            case "cyan": {
                par.startColor = Color.cyan;
                break;
            }
            default: {
                break;
            }
        }
    }
}
