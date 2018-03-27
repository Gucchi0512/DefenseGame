using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    ParticleSystem par;
    //public GameObject spown;
    //enemyspown color;
    // Use this for initialization
    
    void Start () {
        par = GetComponent<ParticleSystem>();
    }
    
    public void ColorChange(string color) {
        var main = par.main;
        switch (color) {
            case "red": {
                main.startColor = new Color(1, 0, 0);
                break;
            }
            case "blue": {
                main.startColor = new Color(0, 0, 1);
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
            default: {
                break;
            }
        }
    }
}
