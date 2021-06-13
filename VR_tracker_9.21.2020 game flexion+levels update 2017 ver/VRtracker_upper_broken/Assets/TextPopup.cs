using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextPopup : MonoBehaviour {
    
    private float DestroyTime = 0.5f; //smaller or larger = faster?
    

	// Use this for initialization
	void Start () {
        Destroy(gameObject, DestroyTime);
	}

}
