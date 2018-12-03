using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour {
    [SerializeField] private GameObject magicbullet;
    private ParticleSystem particle;
    private bool flag=false;//魔法の有り無し
    private GameObject magbullet;
    private float bulletsize=0;

    // Use this for initialization
	void Start () {
        particle = magicbullet.GetComponentInChildren<ParticleSystem>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !flag) {
            magbullet = Instantiate(magicbullet, this.transform.position, this.transform.rotation);
            flag = true;
        }else if (Input.GetMouseButton(0)) {
            particle.Play();
            bulletsize += 0.01f;
            magbullet.transform.localScale = new Vector3(bulletsize, bulletsize, bulletsize);
        } else {
            particle.Stop();
            if (flag) {
                float speed = 2.0f;
                Vector3 force = this.transform.forward * (speed - bulletsize);
                magbullet.GetComponent<Rigidbody>().AddForce(force);
                flag = false;
            }
        }
    }
}
