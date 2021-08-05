using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class createEndpointLists : MonoBehaviour {

    public float armLength;
    public float armLength2;
    public float offset; //for arm length. need to calculate. 
    public List<Vector3> endpoints = new List<Vector3>();   //this is for passive ROM. only full extension. 
    public List<Vector3> endpointsHard = new List<Vector3>();
    public List<Vector3> endpointsMed = new List<Vector3>();
    public List<Vector3> endpointsEasy = new List<Vector3>();
    public List<Vector3> endpointsFood = new List<Vector3>();
    public List<Vector3> endpointsClose = new List<Vector3>();
    public List<Vector3> endpointsFar = new List<Vector3>();
    public List<Vector3> endpointsWaist = new List<Vector3>();
    public List<Vector3> endpointsShoulder = new List<Vector3>();
    public List<Vector3> endpointsHead = new List<Vector3>();
    public List<Vector3> endpointsUpper = new List<Vector3>();
    public List<Vector3> endpointsLower = new List<Vector3>();

    public int theta;   //180
    public float phi;   //90
    public int theta2;  //135
    public float phi2;  //90
    //public int passiveIndex = 0;

    public Vector3 v1;
    public Vector3 v2;

    public SteamVR_TestThrow testThrow;
    public Create_vMarkers cylinder;

    //function for determining position of reaching object
    private Vector3 objectPosition(float theta, float phi, float theorArmLength, GameObject shoulderJoint)
    {
        Vector3 pos = new Vector3(shoulderJoint.transform.position.x + theorArmLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad), shoulderJoint.transform.position.y + theorArmLength * Mathf.Cos(theta * Mathf.Deg2Rad), shoulderJoint.transform.position.z + theorArmLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Cos(phi * Mathf.Deg2Rad));
        return pos;
    }

    // Use this for initialization
    public void generateEndpoints()
    {
        //Debug.Log("run generate endpoints");
        endpoints.Clear();
        endpointsEasy.Clear();
        endpointsMed.Clear();
        endpointsHard.Clear();
        endpointsFood.Clear();
        //armLength = 0.7f;
        offset = .215f;
        //armLength = offset + GameObject.FindGameObjectWithTag("upperarm_cube").transform.localScale.z + GameObject.FindGameObjectWithTag("forearm_cube").transform.localScale.z;
        //Debug.Log("armlength cylinder" + armLength);
        //Debug.Log("cylinderUA" + GameObject.FindGameObjectWithTag("upperarm_cube").transform.localScale.z);
        //Debug.Log("cylinderFA" + GameObject.FindGameObjectWithTag("forearm_cube").transform.localScale.z);

        v2 = (testThrow.RACR.transform.position - testThrow.RLELB.transform.position);
        v1 = (testThrow.RRS.transform.position - testThrow.RLELB.transform.position);
        armLength = offset + v1.magnitude + v2.magnitude;
        //Debug.Log("armlength vector" + armLength2);
        //Debug.Log("vectorUA" + v1.magnitude);
        //Debug.Log("vectorFA" + v2.magnitude);

        //passiveIndex = 0;
        if (testThrow.handDrop.value == 0) //right hand
        {
            theta = 180;
            phi = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45;
            //vertical points
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    theta = theta - 45;
                    Vector3 p = objectPosition(theta, phi, armLength, testThrow.RACR);
                    endpoints.Add(p);
                    endpointsFood.Add(p);
                    endpointsFar.Add(p);
                    endpointsClose.Add(pFlex);
                    //add all flexion points for food. 
                    Vector3 pFlex = objectPosition(theta, phi, 0.1f * armLength, testThrow.RACR);
                    endpointsFood.Add(pFlex);
                    switch (j)
                    {
                        // j = 0
                        case 0:
                            endpointsWaist.Add(p);
                        // j = 1
                        case 1:
                            endpointsShoulder.Add(p);
                        // j = 2
                        case 2:
                            endpointsHead.Add(p);
                    }

                }
                phi = phi + 45;
                theta = 180;
                    /*
                     * 
                     * 
                     * 
                    // old code for adding points to list
                    theta = 180;
                    phi = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45;
                    //vertical points
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            theta = theta - 45;
                            //Vector3 p = new Vector3(testThrow.shoulderjoint.transform.position.x + armLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad), testThrow.shoulderjoint.transform.position.y + armLength * Mathf.Cos(theta * Mathf.Deg2Rad), testThrow.shoulderjoint.transform.position.z + armLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Cos(phi * Mathf.Deg2Rad));
                            Vector3 p = objectPosition(theta, phi, armLength, testThrow.RACR);
                            endpoints.Add(p);
                            endpointsFood.Add(p);
                            //add all flexion points for food. 
                            Vector3 pFlex = objectPosition(theta, phi, 0.1f * armLength, testThrow.RACR);
                            endpointsFood.Add(pFlex);

                            if (j == 0)
                            {
                                endpointsEasy.Add(p);
                                endpointsEasy.Add(pFlex);
                                endpointsWaist.Add(p);
                                endpointsWaist.Add(pFlex);
                            }
                            else if (j == 1)
                            {
                                endpointsShoulder.Add(p);
                                endpointsShoulder.Add(pFlex);
                            }
                            else if (j == 2)
                            {
                                endpointsHead.Add(p);
                                endpointsHead.Add(pFlex);
                            }
                            else if ((i == 1 && j == 2) || (i == 2 && j == 2) || (j == 1))
                            {
                                endpointsMed.Add(p);
                                endpointsMed.Add(pFlex);
                            }
                            else if ((i == 0 && j == 2) || (i == 3 && j == 2))
                            {
                                endpointsHard.Add(p);
                                endpointsHard.Add(pFlex);
                            }
                        }
                        phi = phi + 45;
                        theta = 180;
                    }



                    //unneeded?
                    //horizontal points
                    theta2 = 135;
                    phi2 = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180;
                    for (int i2 = 0; i2 < 3; i2++)  
                    {
                        for (int j2 = 0; j2 < 3; j2++)
                        {
                            phi2 = phi2 - 45;
                            Vector3 p = objectPosition(theta2, phi2, armLength, testThrow.RACR);
                            endpoints.Add(p);
                            endpointsFood.Add(p);
                            //added flexion for food. 
                            Vector3 pFlex = objectPosition(theta2, phi2, 0.1f * armLength, testThrow.RACR);
                            endpointsFood.Add(pFlex);

                            if (i2 == 0)
                            {
                                endpointsEasy.Add(p);
                                endpointsEasy.Add(pFlex);
                            }
                            else if (i2 == 1)
                            {
                                endpointsMed.Add(p);
                                endpointsMed.Add(pFlex);
                            }
                            else if (i2 == 2)
                            {
                                endpointsHard.Add(p);
                                endpointsHard.Add(pFlex);
                            }
                        }

                        theta2 = theta2 - 45;
                        phi2 = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180;
                    }
                    */
                //points behind -- added flexion for dragons
                Vector3 p_behind1 = objectPosition(135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, armLength, testThrow.RACR);
                endpoints.Add(p_behind1);
                endpointsHard.Add(p_behind1);
                Vector3 p_behind1Flex = objectPosition(135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, 0.1f * armLength, testThrow.RACR);
                endpointsHard.Add(p_behind1Flex);

                Vector3 p_behind2 = objectPosition(90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, armLength, testThrow.RACR);
                endpoints.Add(p_behind2);
                endpointsHard.Add(p_behind2);
                Vector3 p_behind2Flex = objectPosition(90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, 0.1f * armLength, testThrow.RACR);
                endpointsHard.Add(p_behind2Flex);

                Vector3 p_behind3 = objectPosition(45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, armLength, testThrow.RACR);
                endpoints.Add(p_behind3);
                endpointsHard.Add(p_behind3);
                Vector3 p_behind3Flex = objectPosition(45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, 0.1f * armLength, testThrow.RACR);
                endpointsHard.Add(p_behind3Flex);
            }
        }

        else if (testThrow.handDrop.value == 1) //left hand
        {
            theta = 180;
            phi = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    theta = theta - 45;
                    //Vector3 p = new Vector3(testThrow.shoulderjoint.transform.position.x + armLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad), testThrow.shoulderjoint.transform.position.y + armLength * Mathf.Cos(theta * Mathf.Deg2Rad), testThrow.shoulderjoint.transform.position.z + armLength * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Cos(phi * Mathf.Deg2Rad));
                    Vector3 p = objectPosition(theta, phi, armLength, testThrow.RACR);
                    endpoints.Add(p);
                    endpointsFood.Add(p);
                    //add all flexion points for food. 
                    Vector3 pFlex = objectPosition(theta, phi, 0.1f * armLength, testThrow.RACR);
                    endpointsFood.Add(pFlex);

                    if (j == 0)
                    {
                        endpointsEasy.Add(p);
                        endpointsEasy.Add(pFlex);
                    }
                    else if ((i == 1 && j == 2) || (i == 2 && j == 2) || (j == 1))
                    {
                        endpointsMed.Add(p);
                        endpointsMed.Add(pFlex);
                    }
                    else if ((i == 0 && j == 2) || (i == 3 && j == 2))
                    {
                        endpointsHard.Add(p);
                        endpointsHard.Add(pFlex);
                    }
                }
                phi = phi + 45;
                theta = 180;
            }



            // unneeded?
            /*
            theta2 = 135;
            phi2 = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180;
            for (int i2 = 0; i2 < 3; i2++)
            {
                for (int j2 = 0; j2 < 3; j2++)
                {
                    phi2 = phi2 + 45;
                    Vector3 p = objectPosition(theta2, phi2, armLength, testThrow.RACR);
                    endpoints.Add(p);
                    endpointsFood.Add(p);
                    //added flexion for food. 
                    Vector3 pFlex = objectPosition(theta2, phi2, 0.1f * armLength, testThrow.RACR);
                    endpointsFood.Add(pFlex);

                    if (i2 == 0)
                    {
                        endpointsEasy.Add(p);
                        endpointsEasy.Add(pFlex);
                    }
                    else if (i2 == 1)
                    {
                        endpointsMed.Add(p);
                        endpointsMed.Add(pFlex);
                    }
                    else if (i2 == 2)
                    {
                        endpointsHard.Add(p);
                        endpointsHard.Add(pFlex);
                    }
                }
                theta2 = theta2 - 45;
                phi2 = cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180;
            }
            */
            //points behind -- added flexion for dragons, no behind for food. 
            Vector3 p_behind1 = objectPosition(135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, armLength, testThrow.RACR);
            endpoints.Add(p_behind1);
            endpointsHard.Add(p_behind1);
            Vector3 p_behind1Flex = objectPosition(135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, 0.1f * armLength, testThrow.RACR);
            endpointsHard.Add(p_behind1Flex);

            Vector3 p_behind2 = objectPosition(90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, armLength, testThrow.RACR);
            endpoints.Add(p_behind2);
            endpointsHard.Add(p_behind2);
            Vector3 p_behind2Flex = objectPosition(90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, 0.1f * armLength, testThrow.RACR);
            endpointsHard.Add(p_behind2Flex);

            Vector3 p_behind3 = objectPosition(45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, armLength, testThrow.RACR);
            endpoints.Add(p_behind3);
            endpointsHard.Add(p_behind3);
            Vector3 p_behind3Flex = objectPosition(45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, 0.1f * armLength, testThrow.RACR);
            endpointsHard.Add(p_behind3Flex);
        }


        //for top and bottom points -- added dragon and food flexion points. 
        Vector3 p_top = objectPosition(0, 90, armLength, testThrow.RACR);
        endpoints.Add(p_top);
        endpointsHard.Add(p_top);
        endpointsFood.Add(p_top);
        endpointsUpper.Add(p_top);

        Vector3 p_topFlex = objectPosition(0, 90, 0.1f * armLength, testThrow.RACR);
        endpointsHard.Add(p_topFlex);
        endpointsFood.Add(p_topFlex);

        Vector3 p_bottom = objectPosition(180, 90, armLength, testThrow.RACR);
        endpoints.Add(p_bottom);
        endpointsEasy.Add(p_bottom);
        endpointsFood.Add(p_bottom);
        endpointsLower.Add(p_bottom);

        Vector3 p_bottomFlex = objectPosition(180, 90, 0.1f * armLength, testThrow.RACR);
        endpointsEasy.Add(p_bottomFlex);
        endpointsFood.Add(p_bottomFlex);

        //generate the randomized lists for game easy,med,hard endpoints
        System.Random rnd = new System.Random();
        endpointsEasy = (from item in endpointsEasy
                         orderby rnd.Next()
                         select item).ToList();




        testThrow.startPassiveButton.SetActive(true);
        //testThrow.endpointsButton.SetActive(false);
        testThrow.calibrateCanvas.SetActive(false);
    }	
}
