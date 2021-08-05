using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_vMarkers : MonoBehaviour {

    public GameObject leftSphere;
    public GameObject rightSphere;
    public GameObject RACR_sphere;
    public GameObject Relbow_sphere;
    public GameObject Rwrist_sphere;

    public Transform cylinderPrefab;
    //public GameObject cylinder;
    public GameObject cylinder1;
    public GameObject cylinder2;
    public GameObject cylinder3;
    public GameObject cylinder4;
    public GameObject cylinder5;

    public Material yellow; 

    public SteamVR_TestThrow testThrow;

    /////////FUNCTIONS////////
    private GameObject InstantiateCylinder(Transform cylinderPrefab, Vector3 beginPoint, Vector3 endPoint, string text)
    {
        GameObject cylinder = Instantiate<GameObject>(cylinderPrefab.gameObject, Vector3.zero, Quaternion.identity);
        UpdateCylinderPosition(cylinder, beginPoint, endPoint);
        cylinder.gameObject.tag = text;
        return cylinder; 
    }

    private void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint)
    {
        Vector3 offset = endPoint - beginPoint;
        Vector3 position = beginPoint + (offset / 2.0f);

        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);
        Vector3 localScale = cylinder.transform.localScale;
        localScale.z = (endPoint - beginPoint).magnitude;
        cylinder.transform.localScale = localScale;
    }

    // Use this for initialization
    public void calibrate()
    {
        testThrow.racr_edit = false;
        testThrow.c7_edit = false;
        testThrow.chest_edit = false;
        testThrow.rfa_edit = false;
        testThrow.rlelb_edit = false;
        testThrow.rmelb_edit = false;
        testThrow.rrs_edit = false;
        testThrow.rus_edit = false;
        testThrow.strn_edit = false;
        testThrow.t8_edit = false;

        testThrow.calibrated = true;

        leftSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftSphere.transform.position = new Vector3((testThrow.STRN.transform.position.x + testThrow.C7.transform.position.x) / 2, (testThrow.STRN.transform.position.y + testThrow.C7.transform.position.y) / 2, (testThrow.STRN.transform.position.z + testThrow.C7.transform.position.z) / 2);
        leftSphere.transform.localScale = new Vector3(0.029f, 0.029f, 0.029f);
        leftSphere.name = "TorsoProximal";
        leftSphere.tag = "TorsoProximal";
        leftSphere.GetComponent<Renderer>().material = yellow;

        rightSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightSphere.transform.position = new Vector3((testThrow.CHEST.transform.position.x + testThrow.T8.transform.position.x) / 2, (testThrow.CHEST.transform.position.y + testThrow.T8.transform.position.y) / 2, (testThrow.CHEST.transform.position.z + testThrow.T8.transform.position.z) / 2);
        rightSphere.transform.localScale = new Vector3(0.02941178f, 0.02941178f, 0.02941178f);
        rightSphere.name = "TorsoDistal";
        rightSphere.tag = "TorsoDistal";
        rightSphere.GetComponent<Renderer>().material = yellow;

        RACR_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        RACR_sphere.transform.position = new Vector3(testThrow.RACR.transform.position.x, (testThrow.RACR.transform.position.y - 0.03f), testThrow.RACR.transform.position.z);
        RACR_sphere.transform.localScale = new Vector3(0.02941178f, 0.02941178f, 0.02941178f);
        RACR_sphere.name = "R_Shoulder";
        RACR_sphere.tag = "R_Shoulder";
        RACR_sphere.GetComponent<Renderer>().material = yellow;

        Relbow_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Relbow_sphere.transform.position = new Vector3((testThrow.RLELB.transform.position.x + testThrow.RMELB.transform.position.x) / 2, (testThrow.RLELB.transform.position.y + testThrow.RMELB.transform.position.y) / 2, (testThrow.RLELB.transform.position.z + testThrow.RMELB.transform.position.z) / 2);
        Relbow_sphere.transform.localScale = new Vector3(0.02941178f, 0.02941178f, 0.02941178f);
        Relbow_sphere.name = "R_Elbow";
        Relbow_sphere.tag = "R_Elbow";
        Relbow_sphere.GetComponent<Renderer>().material = yellow;

        Rwrist_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Rwrist_sphere.transform.position = new Vector3((testThrow.RUS.transform.position.x + testThrow.RRS.transform.position.x) / 2, (testThrow.RUS.transform.position.y + testThrow.RRS.transform.position.y) / 2, (testThrow.RUS.transform.position.z + testThrow.RRS.transform.position.z) / 2);
        Rwrist_sphere.transform.localScale = new Vector3(0.02941178f, 0.02941178f, 0.02941178f);
        Rwrist_sphere.name = "R_Wrist";
        Rwrist_sphere.tag = "R_Wrist";
        Rwrist_sphere.GetComponent<Renderer>().material = yellow;

        /////CREATE CYLINDERS///////
        cylinder1 = InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, rightSphere.transform.position, " ");
        cylinder2 = InstantiateCylinder(cylinderPrefab, leftSphere.transform.position, RACR_sphere.transform.position, " ");
        cylinder3 = InstantiateCylinder(cylinderPrefab, RACR_sphere.transform.position, Relbow_sphere.transform.position, " ");
        cylinder4 = InstantiateCylinder(cylinderPrefab, Relbow_sphere.transform.position, Rwrist_sphere.transform.position, "upperarm_cube");
        cylinder5 = InstantiateCylinder(cylinderPrefab, testThrow.RMELB.transform.position, testThrow.RLELB.transform.position, "forearm_cube");
    }

    // Update is called once per frame
    void Update()
    {
        if (testThrow.calibrated)
        {
            leftSphere.transform.position = new Vector3((testThrow.STRN.transform.position.x + testThrow.C7.transform.position.x) / 2, (testThrow.STRN.transform.position.y + testThrow.C7.transform.position.y) / 2, (testThrow.STRN.transform.position.z + testThrow.C7.transform.position.z) / 2);
            rightSphere.transform.position = new Vector3((testThrow.CHEST.transform.position.x + testThrow.T8.transform.position.x) / 2, (testThrow.CHEST.transform.position.y + testThrow.T8.transform.position.y) / 2, (testThrow.CHEST.transform.position.z + testThrow.T8.transform.position.z) / 2);
            RACR_sphere.transform.position = new Vector3(testThrow.RACR.transform.position.x, (testThrow.RACR.transform.position.y - 0.03f), testThrow.RACR.transform.position.z);
            Relbow_sphere.transform.position = new Vector3((testThrow.RLELB.transform.position.x + testThrow.RMELB.transform.position.x) / 2, (testThrow.RLELB.transform.position.y + testThrow.RMELB.transform.position.y) / 2, (testThrow.RLELB.transform.position.z + testThrow.RMELB.transform.position.z) / 2);
            Rwrist_sphere.transform.position = new Vector3((testThrow.RUS.transform.position.x + testThrow.RRS.transform.position.x) / 2, (testThrow.RUS.transform.position.y + testThrow.RRS.transform.position.y) / 2, (testThrow.RUS.transform.position.z + testThrow.RRS.transform.position.z) / 2);

            ////CYLINDER UPDATE////////
            UpdateCylinderPosition(cylinder1, leftSphere.transform.position, rightSphere.transform.position);
            UpdateCylinderPosition(cylinder2, leftSphere.transform.position, RACR_sphere.transform.position);
            UpdateCylinderPosition(cylinder3, RACR_sphere.transform.position, Relbow_sphere.transform.position);
            UpdateCylinderPosition(cylinder4, Relbow_sphere.transform.position, Rwrist_sphere.transform.position);
            UpdateCylinderPosition(cylinder5, testThrow.RMELB.transform.position, testThrow.RLELB.transform.position);
        }
    }
}

