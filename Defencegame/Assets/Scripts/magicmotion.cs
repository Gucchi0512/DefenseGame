using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicmotion : MonoBehaviour {
    ParticleSystem[] particle;
    float chargetime = 0.0f;
    float speed = 1000.0f;
    float power = 25.0f;
    GameObject player;
    bool left=false;
    public GameObject rigpos;
    // Use this for initialization
    void Start () {
        particle = this.GetComponentsInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("MainCamera");    	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)&&!left) {
            this.transform.position = rigpos.transform.position;
            if (!particle[0].isPlaying)particle[0].Play();
            chargetime += Time.deltaTime;
            if(transform.localScale.x <= 1.0) transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        if (Input.GetMouseButtonUp(0)) {
            Vector3 force;
            Destroy(particle[0]);
            particle[1].Play();
            particle[2].Play();
            force = player.transform.forward * speed;
            GetComponent<Rigidbody>().AddForce(force);
            left = true;
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if (!(collision.gameObject.tag=="Player")) {
            Destroy(gameObject);
            if (collision.gameObject.tag == "enemy") {
                Enemystatus hitenemy = collision.gameObject.GetComponent<Enemystatus>();
                hitenemy.hp -= (power + chargetime) - hitenemy.magicres;
            }
        }
    }
}
