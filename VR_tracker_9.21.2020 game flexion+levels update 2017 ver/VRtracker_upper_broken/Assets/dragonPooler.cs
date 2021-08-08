using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonPooler : MonoBehaviour {

    public GameObject pooledObj;
    public GameObject pooledObj2;
    public GameObject pooledObj3;
    public int pooledAmount = 3;
    public bool willGrow = false;
    public List<GameObject> pooledObjs;
    public GameObject obj;
    public GameObject obj2;
    public GameObject obj3;

    void Start()
    {//name each obj here. and use that to determine the score? 
        pooledObjs = new List<GameObject>();
        GameObject obj = (GameObject)Instantiate(pooledObj);
        GameObject obj2 = (GameObject)Instantiate(pooledObj2);
        GameObject obj3 = (GameObject)Instantiate(pooledObj3);
        obj.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj.name = "drag1";
        obj2.name = "drag2";
        obj3.name = "drag3";
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
