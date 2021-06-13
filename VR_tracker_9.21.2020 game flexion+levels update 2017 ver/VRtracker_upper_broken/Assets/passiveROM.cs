using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passiveROM : MonoBehaviour {

    public GameObject lineRenderer;
    private int numPoints = 25;
    private Vector3[] positions = new Vector3[25];

    public GameObject lineRenderer2;
    private int numPoints2 = 25;
    private Vector3[] positions2 = new Vector3[25];

    public GameObject lineRenderer3;
    private int numPoints3 = 25;
    private Vector3[] positions3 = new Vector3[25];

    public GameObject lineRenderer4;
    private int numPoints4 = 25;
    private Vector3[] positions4 = new Vector3[25];

    public List<GameObject> dots;
    //public Material grey; 

    public createEndpointLists endpointsScript;
    public SteamVR_TestThrow testThrow;
    public dotPool dotPool;
    public Create_vMarkers cylinder; 

    private void DrawCurve(float theta, float phi, GameObject lineRender, int nP, Vector3[] pos)
    {
        for (int i = 0; i < nP; i++)
        {
            float r = endpointsScript.armLength;
            float angle = 180 - ((i / (float)nP) * (180 - theta));
            float x = r * Mathf.Sin(angle * Mathf.Deg2Rad) * Mathf.Sin(phi * Mathf.Deg2Rad);
            float y = r * Mathf.Cos(angle * Mathf.Deg2Rad);
            float z = r * Mathf.Sin(angle * Mathf.Deg2Rad) * Mathf.Cos(phi * Mathf.Deg2Rad);

            pos[i] = new Vector3(testThrow.RACR.transform.position.x + x, testThrow.RACR.transform.position.y + y, testThrow.RACR.transform.position.z + z);
        }
        lineRender.GetComponent<LineRenderer>().SetPositions(pos);
    }

    private void DrawCurve2(float s, float theta, float phi, GameObject lineRender, int nP, Vector3[] pos)
    {
        for (int i = 0; i < nP; i++)
        {
            float r = endpointsScript.armLength;
            float angle = s - ((i / (float)nP) * (s - phi));   //start point of curve for the horizontal sweeps.
            float x = r * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = r * Mathf.Cos(theta * Mathf.Deg2Rad);
            float z = r * Mathf.Sin(theta * Mathf.Deg2Rad) * Mathf.Cos(angle * Mathf.Deg2Rad);
            pos[i] = new Vector3(testThrow.RACR.transform.position.x + x, testThrow.RACR.transform.position.y + y, testThrow.RACR.transform.position.z + z);
        }
        lineRender.GetComponent<LineRenderer>().SetPositions(pos);
    }

    void Start()
    {


        lineRenderer.GetComponent<LineRenderer>().positionCount = numPoints;
        lineRenderer.GetComponent<LineRenderer>().startWidth = 0.025f;
        lineRenderer.GetComponent<LineRenderer>().endWidth = 0.025f;

        lineRenderer2.GetComponent<LineRenderer>().positionCount = numPoints;
        lineRenderer2.GetComponent<LineRenderer>().startWidth = 0.025f;
        lineRenderer2.GetComponent<LineRenderer>().endWidth = 0.025f;

        lineRenderer3.GetComponent<LineRenderer>().positionCount = numPoints;
        lineRenderer3.GetComponent<LineRenderer>().startWidth = 0.025f;
        lineRenderer3.GetComponent<LineRenderer>().endWidth = 0.025f;

        lineRenderer4.GetComponent<LineRenderer>().positionCount = numPoints;
        lineRenderer4.GetComponent<LineRenderer>().startWidth = 0.025f;
        lineRenderer4.GetComponent<LineRenderer>().endWidth = 0.025f;


    }

    // Use this for initialization
    public void chunk1()
    {
        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        lineRenderer.SetActive(true);
        lineRenderer2.SetActive(true);
        lineRenderer3.SetActive(true);
        lineRenderer4.SetActive(true);

        


        if (testThrow.handDrop.value == 0)
        {
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45, lineRenderer, numPoints, positions);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, lineRenderer2, numPoints2, positions2);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 135, lineRenderer3, numPoints3, positions3);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, lineRenderer4, numPoints4, positions4);

            for (int i = 0; i < 12; i++)
            {
                var dot = dotPool.GetPooledObject();
                dot.transform.position = endpointsScript.endpoints[i];
                dots.Add(dot);
                dot.SetActive(true);
            }
        }

        if(testThrow.handDrop.value == 1)
        {
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, lineRenderer, numPoints, positions);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 225, lineRenderer2, numPoints2, positions2);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, lineRenderer3, numPoints3, positions3);
            DrawCurve(0, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 315, lineRenderer4, numPoints4, positions4);

            for (int i = 0; i < 12; i++)
            {
                var dot = dotPool.GetPooledObject();
                dot.transform.position = endpointsScript.endpoints[i];
                dots.Add(dot);
                dot.SetActive(true);
            }
        }

        Debug.Log("chunk1");
    }

    public void chunk2()
    {
        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        lineRenderer.SetActive(true);
        lineRenderer2.SetActive(true);
        lineRenderer3.SetActive(true);
        lineRenderer4.SetActive(false);

        if (testThrow.handDrop.value == 0)
        {
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45, lineRenderer, numPoints, positions);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180 , 90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45, lineRenderer2, numPoints2, positions2);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 45, lineRenderer3, numPoints3, positions3);
        }

        if (testThrow.handDrop.value == 1)
        {
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 315, lineRenderer, numPoints, positions);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 315, lineRenderer2, numPoints2, positions2);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 315, lineRenderer3, numPoints3, positions3);
        }

        for (int i2 = 12; i2 < 21; i2++)
        {
            var dot = dotPool.GetPooledObject();
            dot.transform.position = endpointsScript.endpoints[i2];
            dots.Add(dot);
            dot.SetActive(true);
        }

        Debug.Log("chunk2");
    }

    public void chunk3()
    {
        for (int i = 0; i < dotPool.pooledObjs.Count; i++)
        {
            dotPool.pooledObjs[i].SetActive(false);
        }

        lineRenderer.SetActive(true);
        lineRenderer2.SetActive(true);
        lineRenderer3.SetActive(true);
        lineRenderer4.SetActive(false);

        if (testThrow.handDrop.value == 0)
        {
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, lineRenderer, numPoints, positions);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, lineRenderer2, numPoints2, positions2);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 270, lineRenderer3, numPoints3, positions3);
        }

        if (testThrow.handDrop.value == 1)
        {
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 45, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, lineRenderer, numPoints, positions);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 90, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, lineRenderer2, numPoints2, positions2);
            DrawCurve2(cylinder.cylinder2.transform.localRotation.eulerAngles.y + 180, 135, cylinder.cylinder2.transform.localRotation.eulerAngles.y + 90, lineRenderer3, numPoints3, positions3);
        }

        for (int i3 = 21; i3 < 24; i3++)
        {
            var dot = dotPool.GetPooledObject();
            dot.transform.position = endpointsScript.endpoints[i3];
            dots.Add(dot);
            dot.SetActive(true);
        }

        Debug.Log("chunk3");
    }

    /*public void Update()
    {
        ElbowAngle = Mathf.Atan2(Vector3.Cross(vector.v1, vector.v2).magnitude, Vector3.Dot(vector.v1, vector.v2));
        Debug.Log("vector elbow angle" + ElbowAngle);

        ElbowAngleC = Quaternion.Angle(GameObject.FindGameObjectWithTag("upperarm_cube").transform.rotation, GameObject.FindGameObjectWithTag("forearm_cube").transform.rotation);
        Debug.Log("cylinder elbow angle" + ElbowAngleC);
    }*/
}
