using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour {
    [SerializeField] private GameObject magicbullet;
    private GameObject magbullet;

    // Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            magbullet = Instantiate(magicbullet, this.transform.position, this.transform.rotation);
            magbullet.GetComponent<magicmotion>().rigpos = this.gameObject;
        }
    }
}
