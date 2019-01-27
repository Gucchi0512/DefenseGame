using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    private GameObject[] enemy;
    int enemynum;
    public float spownspan = 10.0f;
    float passedtime = 0.0f;
    GameObject player;

    ChangeColor[] chcolors;
    ParticleSystem[] pss;
    Animator animator;
    // Use this for initialization
    void Start() {
        player=GameObject.FindGameObjectWithTag("Player");
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
        if(player.GetComponent<PlayingManage>().isPlaying){
            animator.SetTrigger("summons");
            enemynum = Random.Range(1, 5)%4;
            passedtime += Time.deltaTime;
            foreach (var items in pss) {
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

    
}