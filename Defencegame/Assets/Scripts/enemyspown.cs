using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspown : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    int enemynum;
    public float spownspan = 10.0f;
    float passedtime = 0.0f;
    ChangeColor[] chcolors;
    ParticleSystem[] pss;
    Animator animator;
    // Use this for initialization
    void Start() {
        enemy=GameObject.FindGameObjectsWithTag("enemy");
        animator = GetComponentInChildren<Animator>();
        pss = GetComponentsInChildren<ParticleSystem>();
        chcolors = GetComponentsInChildren<ChangeColor>();
        foreach(var item in pss) {
            item.Stop();
        }
    }

    // Update is called once per frame
    void Update() {
        animator.SetTrigger("summons");
        enemynum = Random.Range(1, 5)%4;
        passedtime += Time.deltaTime;
        foreach (var items in pss) {
            //items.Stop();
            if(!items.isPlaying)items.Play();
        }
        if (passedtime >= spownspan) {
            passedtime = 0.0f;
            foreach(var color in chcolors)color.ColorChange(color:"black");
            Instantiate(enemy[enemynum], transform.position, GetComponentInParent<Transform>().rotation);
        }
        if (passedtime >= 2.0f) {
            foreach(var color in chcolors)color.ColorChange(color: "red");
        }
    }

    
}