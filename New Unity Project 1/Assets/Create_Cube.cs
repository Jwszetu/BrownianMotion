using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Cube : MonoBehaviour {

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    GameObject Holder;

    int[] InstanceID_Num;
    Vector3 StartPosition;


    #region Stuff_that_works
    // Use this for initialization
    void Start () {

        PoolManager.instance.CreatePool_ActivePool(prefab1, 5);
        PoolManager.instance.CreatePool_ActivePool(prefab2, 500);
        PoolManager.instance.CreatePool_ActivePool(prefab3, 500);
    }
    Vector3 RandomVector(int lmt)
    {
        float x = Random.Range(-lmt, lmt);
        float y = Random.Range(-lmt, lmt);
        float z = Random.Range(-lmt, lmt);

        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
    void Turn_OffOn_Render()
    {


        /*for (int i = 0; i < InstanceID_Num.Length; i++)
        {
            MeshRenderer Child; //Holder.transform.Find(InstanceID_Num[i].ToString()).GetComponent<MeshRenderer>() as MeshRenderer;
            Child.enabled = !Child.enabled;
        }*/
        
    }
    #endregion

}
