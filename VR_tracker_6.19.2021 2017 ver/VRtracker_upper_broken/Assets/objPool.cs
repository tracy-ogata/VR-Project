using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPool : MonoBehaviour {
    public GameObject pooledObj;
    public int pooledAmount = 10;
    public bool willGrow = false;
    public List<GameObject> pooledObjs;

    void Start()
    {
        pooledObjs = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
        //Debug.Log("objects pooled");
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjs.Count; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                //Debug.Log("got object");
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
