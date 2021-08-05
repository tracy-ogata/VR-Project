using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setTracker : MonoBehaviour {

    //dropdown for trackers
    public Dropdown Orange;
    public Dropdown Blue;
    public Dropdown Yellow;

    public GameObject OrangeCube;
    public GameObject BlueCube;
    public GameObject YellowCube;

    public int oValue;
    public int bValue;
    public int yValue;

    public SteamVR_TestThrow testThrow;

    // Use this for initialization
    public void assignTrackers() {
        oValue = Orange.value;
        bValue = Blue.value;
        yValue = Yellow.value;

        // set Trackers to segments
        if (oValue == 0 )
        {
            testThrow.tracker = OrangeCube.transform;
        }

        else if (oValue == 1 )
        {
            testThrow.tracker2 = OrangeCube.transform;
        }

        else if (oValue == 2 )
        {
            testThrow.tracker3 = OrangeCube.transform;
        }

        if (bValue == 0)
        {
            testThrow.tracker = BlueCube.transform;
        }

        else if (bValue == 1)
        {
            testThrow.tracker2 = BlueCube.transform;
        }

        else if (bValue == 2)
        {
            testThrow.tracker3 = BlueCube.transform;
        }

        if (yValue == 0 )
        {
            testThrow.tracker = YellowCube.transform;
        }

        else if (yValue == 1 )
        {
            testThrow.tracker2 = YellowCube.transform;
        }

        else if (yValue == 2 )
        {
            testThrow.tracker3 = YellowCube.transform;
        }

        testThrow.setTrackerCanvas.SetActive(false);
        testThrow.calibrateCanvas.SetActive(true);
    }


	

}
