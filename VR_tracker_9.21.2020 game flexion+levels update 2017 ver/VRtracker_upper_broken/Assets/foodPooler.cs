﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodPooler : MonoBehaviour {

    public GameObject pooledObj;
    public GameObject pooledObj2;
    public GameObject pooledObj3;
    public int pooledAmount = 3;
    public bool willGrow = false;
    public List<GameObject> pooledObjs;


    void Start()
    {//name each obj here. and use that to determine the score? 
        pooledObjs = new List<GameObject>();
        GameObject obj = (GameObject)Instantiate(pooledObj);
        GameObject obj2 = (GameObject)Instantiate(pooledObj2);
        GameObject obj3 = (GameObject)Instantiate(pooledObj3);
        obj.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj.name = "food";
        obj2.name = "food";
        obj3.name = "food";
        pooledObjs.Add(obj);
        pooledObjs.Add(obj2);
        pooledObjs.Add(obj3);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjs.Count; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            pooledObjs.Add(obj);
            return obj;
        }
        return null;
    }
}
