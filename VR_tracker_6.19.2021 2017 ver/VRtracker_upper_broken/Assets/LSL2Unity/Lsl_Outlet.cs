using UnityEngine;
using System.Collections;
using LSL;
using System.Threading;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Lsl_Outlet : MonoBehaviour {


    public float[] sample = new float[3];

    public Transform controller_p;
	public Vector3 Pos;

    public liblsl.StreamOutlet outlet;
    public liblsl.StreamInfo info;

    public string streamName = "left_foot";
    public string streamType = "position";
    public string marker_name = "name";

    public GameObject marker;
    public SteamVR_TestThrow testThrow;

    // Use this for initialization
    void Start () {

        info = new liblsl.StreamInfo(streamName, streamType, 3);
        outlet = new liblsl.StreamOutlet(info);

    }

    // Update is called once per frame
    void Update () {
        if (testThrow.calibrated)
        {
            marker = GameObject.FindGameObjectWithTag(marker_name);
            controller_p = marker.transform;

            Pos = new Vector3(controller_p.position.x, controller_p.position.y, controller_p.position.z);

            sample[0] = Pos.x;
            sample[1] = Pos.y;
            sample[2] = Pos.z;

            outlet.push_sample(sample);
        }
	
	}
}
