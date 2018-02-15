using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();
    static PoolManager _instance;
    public static PoolManager instance{
        get {
            if (_instance == null){
                _instance = FindObjectOfType<PoolManager>();
            }
            return _instance;
        }
    }
    public void Create_InactivePool(GameObject prefab, int poolSzie)
    {
        int poolKey = prefab.GetInstanceID();

        if (!poolDictionary.ContainsKey(poolKey)){
            poolDictionary.Add(poolKey, new Queue<GameObject>());

            for (int i = 0; i < poolSzie; i++){
                GameObject newObject = Instantiate(prefab) as GameObject;
                newObject.SetActive(false);
                poolDictionary[poolKey].Enqueue(newObject);
            }

        }
    }
    public void CreatePool_ActivePool(GameObject prefab, int poolSzie)
    {
        int poolKey = prefab.GetInstanceID();
        const int Position_boundaries = 400;

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
            GameObject Holder = new GameObject();

            for (int i = 0; i < poolSzie; i++)
            {
                Vector3 StartPosition = RandomVector(Position_boundaries);
                GameObject newObject = Instantiate(prefab, StartPosition, Quaternion.identity) as GameObject;
                poolDictionary[poolKey].Enqueue(newObject);
                newObject.transform.parent = Holder.transform;
                Holder.name = prefab.name;
                newObject.name = prefab.name + newObject.GetInstanceID();
            }

        }
    }
    private Vector3 RandomVector(int lmt)
    {
        float x = Random.Range(-lmt, lmt);
        float y = Random.Range(-lmt, lmt);
        float z = Random.Range(-lmt, lmt);

        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
    public void ReuseObject(GameObject prefab, Vector3 postion, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if (poolDictionary.ContainsKey(poolKey))
        {
            GameObject objectToReuse = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.SetActive(true);
            objectToReuse.transform.position = postion;
            objectToReuse.transform.rotation = rotation;
        }
    }
}
