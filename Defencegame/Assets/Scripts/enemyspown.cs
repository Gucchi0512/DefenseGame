using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspown : MonoBehaviour
{
    [SerializeField] private GameObject gobrin;
    [SerializeField] private GameObject hobgobrin;
    [SerializeField] private GameObject wolf;
    [SerializeField] private GameObject troll;
    int enemynum;
    public float spownspan = 10.0f;
    float passedtime = 0.0f;
    ChangeColor[] chcolors;
    ParticleSystem[] pss;
    Animator animator;
    // Use this for initialization
    void Start() {
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
        enemynum = Random.Range(0, 5);
        passedtime += Time.deltaTime;
        foreach (var items in pss) {
            //items.Stop();
            if(!items.isPlaying)items.Play();
        }
        if (passedtime >= spownspan) {
            passedtime = 0.0f;
            foreach(var color in chcolors)color.ColorChange(color:"black");
            if (enemynum >= 0 && enemynum < 5) {
                Instantiate(gobrin, transform.position, GetComponentInParent<Transform>().rotation);
                Debug.Log("Spown");
            } /*else if (enemynum < 8) {
                Instantiate(hobgobrin, transform.position, Quaternion.identity);
            } else if (enemynum < 10) {
                Instantiate(wolf, transform.position, Quaternion.identity);
            } else {
                Instantiate(troll, transform.position, Quaternion.identity);
            }*/
        }
        if (passedtime >= 2.0f) {
            foreach(var color in chcolors)color.ColorChange(color: "red");
        }
    }

    
}