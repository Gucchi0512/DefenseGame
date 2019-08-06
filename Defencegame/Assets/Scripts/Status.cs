using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Status : MonoBehaviour {
	[SerializeField]private float hp;
    public  float maxHp;
	public float speed;
	public float magicres;
	public float power;
	private Animator animator;
    public Slider slider;
    public GameObject deadEff;
	// Use this for initialization
    public float HP {
        get {
            return hp;
        }
        set {
            hp = value;
        }
    }
	void Start () {
        HP = maxHp;
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.tag=="enemy"&&this.hp<=0){
			GetComponent<NavMeshAgent>().isStopped=true;
			AnimatorClipInfo clipInfo = animator.GetCurrentAnimatorClipInfo(0)[0];
			animator.SetBool(clipInfo.clip.name, false);
			animator.SetBool("dead", true);
			StartCoroutine("DeadEnemy");
		}else if(this.gameObject.tag=="Target"){
			//Debug.Log(hp);
			var parent = transform.root.gameObject;
			parent.GetComponentInChildren<CrystalColor>().colorchange(hp);
		}
	}

	public void Damage(float hitpower){
		this.hp-=hitpower;
	}
	private IEnumerator DeadEnemy(){
        slider.gameObject.SetActive(false);
        var eff = Instantiate(deadEff, transform);
        var dead = eff.GetComponentInChildren<ParticleSystem>();
        Debug.Log(eff + " " + dead);
        dead.Play(true);
        yield return new WaitForSeconds(3f); 
        Destroy(this.gameObject);
	}
}
