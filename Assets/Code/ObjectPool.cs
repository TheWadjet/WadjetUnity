using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ObjectPool : MonoBehaviour
{
    public GameObject prefab { get; set; }
    private List<GameObject> cache;
    int maxInstances { get; set; }

    public void Push(GameObject obj)
    {
        if (cache.Count < maxInstances)
        {
            obj.SetActive(false);
            cache.Add(obj);
        }
        else
        {
            Destroy(obj);
        }
    }

    public GameObject Pool(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject i in cache)
        {
            if (i && i.activeInHierarchy == false)
            {
                i.SetActive(true);
                i.transform.position = position;
                i.transform.rotation = rotation;
                return i;
            }
        }
        GameObject obj = Instantiate(prefab, position, rotation) as GameObject;
        cache.Add(obj);
        return obj;
    }


    public ObjectPool(GameObject newPrefab, int newMaxInstances = 20)
    {
        maxInstances = newMaxInstances;
        prefab = newPrefab;
        cache = new List<GameObject>();
        for (int i = 0; i < maxInstances; i++)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            obj.SetActive(false);
            cache.Add(obj);
        }
    }

    public ObjectPool(){ }

}
