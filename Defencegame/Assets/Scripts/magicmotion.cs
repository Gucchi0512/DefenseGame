using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMotion : MonoBehaviour {
    ParticleSystem[] particle;
    public GameObject hitEff;
    float chargetime = 0.0f;
    float speed = 1000.0f;
    float power = 70.0f;
    GameObject player;
    bool left=false;
    public GameObject rigpos;
    float lifetime=0.0f;
    // Use this for initialization
    void Start () {
        particle = this.GetComponentsInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("MainCamera");    	
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)&&!left) {
            this.transform.position = rigpos.transform.position;
            if (!particle[0].isPlaying)particle[0].Play();
            if(chargetime<=75) chargetime += Time.deltaTime;
            if(transform.localScale.x <= 0.5) transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
            Vector3 force;
            Destroy(particle[0]);
            particle[1].Play();
            particle[2].Play();
            force = player.transform.forward * speed;
            GetComponent<Rigidbody>().AddForce(force);
            left = true;
        }
        if(left){
            lifetime+=Time.deltaTime;
            if(lifetime>3) Destroy(gameObject);
        }
	}
    void OnCollisionEnter(Collision  other){
        if(!(other.gameObject.tag=="Player")){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col) {
        var pos = col.gameObject.transform.position;
        if (col.tag == "enemy") {
            var center = col.transform.Find("Center");
            var eff = Instantiate(hitEff, center.transform);
            eff.GetComponentInChildren<ParticleSystem>().Play(true);
            Status hitenemy = col. GetComponent<Status>();
            hitenemy.Damage((power + chargetime) - hitenemy.magicres);
        }
        Destroy(gameObject);
    }
}
