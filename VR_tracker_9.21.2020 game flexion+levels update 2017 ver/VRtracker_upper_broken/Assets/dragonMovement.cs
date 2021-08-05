using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonMovement : MonoBehaviour {

    public SteamVR_TestThrow testThrow;
    public dragonPooler dragonPooler;
    public createEndpointLists endpointsScript;
    public activeROMgame activeROM;

    public int indexE = 0;
    public int indexM = 0;
    public int indexH = 0;
    //public float step;
    public bool active;
    public Vector3 endPointLocation;
    public Create_vMarkers cylinder;

    void OnEnable () {
        if (this.name == "drag1")
        {
            //index = Random.Range(0, endpointsScript.endpointsEasy.Count - 1);
            //endPointLocation = endpointsScript.endpointsEasy[index];
            //test this part//
            endPointLocation = endpointsScript.endpointsEasy[indexE];
            active = true;
            indexE++;
            //if index is greater than the length of the list, need start over. 
            if(indexE > endpointsScript.endpointsEasy.Count - 1)
            {
                indexE = 0; 
            }
        }

        else if(this.name == "drag2")
        {
            indexM = Random.Range(0, endpointsScript.endpointsMed.Count - 1);
            //step = Random.Range(1f, 2.0f);
            endPointLocation = endpointsScript.endpointsMed[indexM];
            active = true;
        }

        else if (this.name == "drag3")
        {
            indexH = Random.Range(0, endpointsScript.endpointsHard.Count - 1);
            //step = Random.Range(1f, 2.0f);
            endPointLocation = endpointsScript.endpointsHard[indexH];
            active = true;
        }

	}

    void Update()
    {  
        if (active)
        {
            this.transform.LookAt(cylinder.cylinder2.transform);
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPointLocation, 1.5f * Time.deltaTime);
        }
    }

    void onDisable()
    {
        active = false; 
    }
}
