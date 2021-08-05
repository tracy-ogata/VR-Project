using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_Parent : MonoBehaviour {

    public Transform marker_transform;
    public GameObject marker;

    void Start()
    {

    }

     void Update()
    {
        if (marker.activeSelf)
        {
            marker_transform.parent = transform;
            marker_transform.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

    }
}
