using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public GameObject canvas;
    public Slider slider;
    private Status status;
    private GameObject player;
    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        status = GetComponent<Status>();

    }

    // Update is called once per frame
    void Update(){
        canvas.transform.LookAt(player.transform.position);
        slider.value = status.HP/status.maxHp;
    }
}
