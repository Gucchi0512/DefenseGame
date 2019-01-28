using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManage : MonoBehaviour
{
    public bool isPlaying=false;

    public float passedTime=0.0f;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying) passedTime=(Time.time-startTime);
        if(OVRInput.GetDown(OVRInput.RawButton.A)&&!isPlaying){
            isPlaying=true;
            startTime=Time.time;
        }
        if((OVRInput.GetDown(OVRInput.RawButton.X)||passedTime>120.0f)&&isPlaying){
            isPlaying=false;
        }
    }
}
