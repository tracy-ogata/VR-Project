using UnityEngine;
using System.Collections;
using LSL;
using System.Threading;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class lsloutlet : MonoBehaviour
{

    public liblsl.StreamOutlet outlet;
    public liblsl.StreamInfo info;

    public float[] sample = new float[3];

    public string streamName = "left_foot";
    public string streamType = "position";

    public Transform controller_p;
    public Vector3 Pos;




    // Use this for initialization
    void Start()
    {
        info = new liblsl.StreamInfo(streamName, streamType, 3);
        outlet = new liblsl.StreamOutlet(info);


    }
    // Update is called once per frame
    void Update()
    {

        Pos = new Vector3(controller_p.position.x, controller_p.position.y, controller_p.position.z);

        sample[0] = Pos.x;
        sample[1] = Pos.y;
        sample[2] = Pos.z;

        outlet.push_sample(sample);

    }
}