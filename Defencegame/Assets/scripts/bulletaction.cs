using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour {
    public float speed=5.0f;
    float bulletsize = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        while (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) {
            if (bulletsize <= (speed - 1.0f)) {
                bulletsize += 0.5f;
                this.transform.localScale += new Vector3(bulletsize, bulletsize, bulletsize);
            }
        }
        Vector3 force;
        force = this.transform.forward * (speed - bulletsize);
        this.GetComponent<Rigidbody>().AddForce(force);
    }
}
