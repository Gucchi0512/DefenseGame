using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour {
    [SerializeField] private GameObject magicbullet;
    [SerializeField] private GameObject laser;
    private GameObject magbullet;
    private GameObject laserobj;
    private GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera");
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            magbullet = Instantiate(magicbullet, this.transform.position, this.transform.localRotation);
            magbullet.GetComponent<magicmotion>().rigpos = this.gameObject;
        } else if(Input.GetMouseButtonDown(1)){
            laserobj = Instantiate(laser, this.transform.position, player.transform.rotation);
            laserobj.GetComponent<ParticleSystem>().Play();
        }
    }
}
