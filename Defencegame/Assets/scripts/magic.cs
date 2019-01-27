using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {
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
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
            magbullet = Instantiate(magicbullet, this.transform.position, this.transform.localRotation);
            magbullet.GetComponent<MagicMotion>().rigpos = this.gameObject;
        } else if(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)){
            laserobj = Instantiate(laser, this.transform.position, player.transform.rotation);
            laserobj.GetComponent<ParticleSystem>().Play();
        }
    }
}
