using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    ParticleSystem par;
    
    void Start () {
        par = GetComponentInChildren<ParticleSystem>();
    }
    
    public void ColorChange(string color) {
        var main = par.main;
        switch (color) {
            case "red": {
                main.startColor = Color.red;
                break;
            }
            case "blue": {
                main.startColor = Color.blue;
                break;
            }
            case "yellow": {
                main.startColor = Color.yellow;
                break;
            }
            case "green": {
                main.startColor = Color.green;
                break;
            }
            case "cyan": {
                main.startColor = Color.cyan;
                break;
            }
            case "black": {
                main.startColor = Color.black;
                break;
            }
            default: {
                break;
            }
        }
    }
}
