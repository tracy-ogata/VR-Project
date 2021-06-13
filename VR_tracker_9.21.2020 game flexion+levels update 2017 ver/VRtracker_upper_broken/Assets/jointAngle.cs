using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jointAngle : MonoBehaviour {
    public float ElbowAngle;
    public Slider angleSlider;
    public Text angleText; 
    public Vector3 v1;
    public Vector3 v2;

    public SteamVR_TestThrow testThrow;

    // Update is called once per frame
    void Update()
    {
        if (testThrow.start_passive)
        {
            v2 = (testThrow.RACR.transform.position - testThrow.RLELB.transform.position);
            v1 = (testThrow.RRS.transform.position - testThrow.RLELB.transform.position);

            ElbowAngle = (Mathf.Atan2(Vector3.Cross(v1, v2).magnitude, Vector3.Dot(v1, v2))) * (180/Mathf.PI);
            //Debug.Log("vector elbow angle" + ElbowAngle);

            angleSlider.value = ElbowAngle;
            angleText.text = ElbowAngle.ToString();
        }

    }
}
