using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspown : MonoBehaviour
{
    public GameObject gobrin;
    public GameObject hobgobrin;
    public GameObject wolf;
    public GameObject troll;
    int enemynum;
    public float spownspan = 10.0f;
    float passedtime = 0.0f;
    ChangeColor chcolor;
    ChangeColor chcolor2;
    ParticleSystem[] pss;
    Animator animator;
    // Use this for initialization
    void Start() {
        animator = GetComponentInChildren<Animator>();
        pss = GetComponentsInChildren<ParticleSystem>();
        chcolor = GetComponent<ChangeColor>();
        chcolor2 = GetComponent<ChangeColor>();
        foreach(var item in pss) {
            item.Stop();
        }
    }

    // Update is called once per frame
    void Update() {
        animator.SetTrigger("summons");
        enemynum = Random.Range(0, 11);
        passedtime += Time.deltaTime;
        foreach (var items in pss) {
            //items.Stop();
            items.Play();
        }
        if (passedtime >= spownspan) {
            passedtime = 0.0f;
            chcolor.ColorChange(color:"black");
            chcolor2.ColorChange(color: "black");
            if (enemynum >= 0 && enemynum < 5) {
                Instantiate(gobrin, transform.position, transform.rotation);
            } /*else if (enemynum < 8) {
                Instantiate(hobgobrin, transform.position, Quaternion.identity);
            } else if (enemynum < 10) {
                Instantiate(wolf, transform.position, Quaternion.identity);
            } else {
                Instantiate(troll, transform.position, Quaternion.identity);
            }*/
        }
        if (passedtime >= 2.0f) {
            chcolor.ColorChange(color: "red");
            chcolor2.ColorChange(color: "red");
        }
    }

    
}