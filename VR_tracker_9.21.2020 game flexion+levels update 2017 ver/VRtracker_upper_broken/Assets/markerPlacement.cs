using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerPlacement : MonoBehaviour {

    public SteamVR_TestThrow testThrow;
    public objPool objectPooler;

    //functions
    GameObject placeMarker(GameObject markerName, string tag, Material color, Transform tracker)
    {
        testThrow.marker.SetActive(true);
        markerName = objectPooler.GetPooledObject();
        markerName.transform.position = testThrow.marker.transform.position;
        markerName.name = tag;
        markerName.tag = tag;
        markerName.GetComponent<Renderer>().material = color;
        markerName.transform.parent = tracker.transform;
        markerName.SetActive(true);
        return markerName;

    }

    void editMarker(GameObject markerName)
    {
        markerName.GetComponent<MeshRenderer>().material = testThrow.col_mat;

        //delete the marker
        if (testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            markerName.SetActive(false);
            testThrow.collidingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ///////PLACE/////////
        if (testThrow.racr_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RACR = placeMarker(testThrow.RACR, "RACR", testThrow.red, testThrow.tracker);
            testThrow.racr_edit = true;
            testThrow.racr_bool = false;
        }

        else if(testThrow.c7_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.C7 = placeMarker(testThrow.C7, "C7", testThrow.orange, testThrow.tracker);
            testThrow.c7_edit = true;
            testThrow.c7_bool = false;
        }

        else if (testThrow.strn_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.STRN = placeMarker(testThrow.STRN, "STRN", testThrow.orange, testThrow.tracker);
            testThrow.strn_edit = true;
            testThrow.strn_bool = false;
        }

        else if (testThrow.chest_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.CHEST = placeMarker(testThrow.CHEST, "CHEST", testThrow.orange, testThrow.tracker);
            testThrow.chest_edit = true;
            testThrow.chest_bool = false;
        }

        else if (testThrow.t8_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.T8 = placeMarker(testThrow.T8, "T8", testThrow.orange, testThrow.tracker);
            testThrow.t8_edit = true;
            testThrow.t8_bool = false;
        }

        else if (testThrow.rlelb_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RLELB = placeMarker(testThrow.RLELB, "RLELB", testThrow.blue, testThrow.tracker2);
            testThrow.rlelb_edit = true;
            testThrow.rlelb_bool = false;
        }

        else if (testThrow.rmelb_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RMELB = placeMarker(testThrow.RMELB, "RMELB", testThrow.blue, testThrow.tracker2);
            testThrow.rmelb_edit = true;
            testThrow.rmelb_bool = false;
        }

        else if (testThrow.rfa_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RFA = placeMarker(testThrow.RFA, "RFA", testThrow.yellow, testThrow.tracker3);
            testThrow.rfa_edit = true;
            testThrow.rfa_bool = false;
        }

        else if (testThrow.rrs_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RRS = placeMarker(testThrow.RRS, "RRS", testThrow.yellow, testThrow.tracker3);
            testThrow.rrs_edit = true;
            testThrow.rrs_bool = false;
        }

        else if (testThrow.rus_bool == true && testThrow.device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            testThrow.RUS = placeMarker(testThrow.RUS, "RUS", testThrow.yellow, testThrow.tracker3);
            testThrow.rus_edit = true;
            testThrow.rus_bool = false;
        }

        ///////EDITING/////////

        if (testThrow.racr_edit && testThrow.collidingObject == testThrow.RACR)
        {
            editMarker(testThrow.RACR);
        }

        else if(testThrow.c7_edit && testThrow.collidingObject == testThrow.C7)
        {
            editMarker(testThrow.C7);
        }

        else if (testThrow.strn_edit && testThrow.collidingObject == testThrow.STRN)
        {
            editMarker(testThrow.STRN);
        }

        else if (testThrow.chest_edit && testThrow.collidingObject == testThrow.CHEST)
        {
            editMarker(testThrow.CHEST);
        }

        else if (testThrow.t8_edit && testThrow.collidingObject == testThrow.T8)
        {
            editMarker(testThrow.T8);
        }

        else if (testThrow.rlelb_edit && testThrow.collidingObject == testThrow.RLELB)
        {
            editMarker(testThrow.RLELB);
        }

        else if (testThrow.rmelb_edit && testThrow.collidingObject == testThrow.RMELB)
        {
            editMarker(testThrow.RMELB);
        }

        else if (testThrow.rfa_edit && testThrow.collidingObject == testThrow.RFA)
        {
            editMarker(testThrow.RFA);
        }

        else if (testThrow.rrs_edit && testThrow.collidingObject == testThrow.RRS)
        {
            editMarker(testThrow.RRS);
        }

        else if (testThrow.rus_edit && testThrow.collidingObject == testThrow.RUS)
        {
            editMarker(testThrow.RUS);
        }

        /////ELSE///////
        else
        {
            if (testThrow.RACR.activeSelf)
            {
                testThrow.RACR.GetComponent<MeshRenderer>().material = testThrow.red;
            }

            if (testThrow.C7.activeSelf)
            {
                testThrow.C7.GetComponent<MeshRenderer>().material = testThrow.orange;
            }

            if (testThrow.STRN.activeSelf)
            {
                testThrow.STRN.GetComponent<MeshRenderer>().material = testThrow.orange;
            }

            if (testThrow.CHEST.activeSelf)
            {
                testThrow.CHEST.GetComponent<MeshRenderer>().material = testThrow.orange;
            }

            if (testThrow.T8.activeSelf)
            {
                testThrow.T8.GetComponent<MeshRenderer>().material = testThrow.orange;
            }

            if (testThrow.RLELB.activeSelf)
            {
                testThrow.RLELB.GetComponent<MeshRenderer>().material = testThrow.blue;
            }

            if (testThrow.RMELB.activeSelf)
            {
                testThrow.RMELB.GetComponent<MeshRenderer>().material = testThrow.blue;
            }

            if (testThrow.RFA.activeSelf)
            {
                testThrow.RFA.GetComponent<MeshRenderer>().material = testThrow.yellow;
            }

            if (testThrow.RUS.activeSelf)
            {
                testThrow.RUS.GetComponent<MeshRenderer>().material = testThrow.yellow;
            }

            if (testThrow.RRS.activeSelf)
            {
                testThrow.RRS.GetComponent<MeshRenderer>().material = testThrow.yellow;
            }

        }
    }


}
