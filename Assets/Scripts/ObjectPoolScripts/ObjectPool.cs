using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    private static ObjectPool instance;

    public List<PoolObject> prefabs;
    private static List<PoolObject> savedObjects;

	// Use this for initialization
	void Start () {
        savedObjects = new List<PoolObject>();
        instance = this;
	}
	

    public static GameObject GetItem(PoolTypes type)
    {
        GameObject SpawnedObject = null;
        PoolObject pObject = savedObjects.Find(obj => obj.PoolType == type);
        if(pObject != null)
        {
            savedObjects.Remove(pObject);
            SpawnedObject = pObject.Object;
            SpawnedObject.SetActive(true);
        }
        else
        {
            pObject = instance.prefabs.Find(obj => obj.PoolType == type);
            SpawnedObject = Instantiate(pObject.Object);
            SpawnedObject.SetActive(true);
            SpawnedObject.transform.parent = instance.transform;
        }

        return SpawnedObject;
    }

    public static void returnItem(GameObject poolObject)
    {
        savedObjects.Add(poolObject.GetComponent<PoolObject>());
        poolObject.SetActive(false);
        poolObject.transform.position = Vector3.zero;


    }
    


}
