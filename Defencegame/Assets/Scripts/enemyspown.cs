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
    float spownspan = 10.0f;
    float passedtime = 0.0f;
    ChangeColor chcolor;
    public GameObject ch;
    // Use this for initialization
    void Start() {
        chcolor = ch.GetComponent<ChangeColor>();
    }

    // Update is called once per frame
    void Update() {
        enemynum = Random.Range(0, 11);
        passedtime += Time.deltaTime;
        if (passedtime >= spownspan) {
            passedtime = 0.0f;
            chcolor.ColorChange(color:"yellow");
            if (enemynum >= 0 && enemynum < 5) {
                Instantiate(gobrin, transform.position, Quaternion.identity);
            } /*else if (enemynum < 8) {
                Instantiate(hobgobrin, transform.position, Quaternion.identity);
            } else if (enemynum < 10) {
                Instantiate(wolf, transform.position, Quaternion.identity);
            } else {
                Instantiate(troll, transform.position, Quaternion.identity);
            }*/
        }
    }
}