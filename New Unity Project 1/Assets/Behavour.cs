using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavour : MonoBehaviour {

    public Vector3 Start_Position;
    public Vector3 Current_Position;
    public Vector3 Directional_Vector;
    public Collider C_ollider;

    // Use this for initialization
    void Start () {


        Start_Position = gameObject.transform.position;
        Directional_Vector = RandomVector(10);

        C_ollider = gameObject.GetComponent<Collider>();
        C_ollider.isTrigger = true;
    }
    Vector3 RandomVector(int lmt)
    {
        float x = Random.Range(-lmt, lmt);
        float y = Random.Range(-lmt, lmt);
        float z = Random.Range(-lmt, lmt);

        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
    Vector3 NewCurrentPosition(int _Time)
    {
        
        Vector3 Current = Start_Position + ((float)_Time / 30 * Directional_Vector);
        return Current;

    }
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Directional_Vector);

       
        
	}
    private void OnTriggerEnter(Collider other)
    {
        
        string Object_name = other.name;
        


        switch (Object_name)
        {
            case "Cube_x":
               
                Directional_Vector.x = -Directional_Vector.x;
                break;
            case "Cube_y":
               
                Directional_Vector.y = -Directional_Vector.y;
                break;
            case "Cube_z":
                
                Directional_Vector.z = -Directional_Vector.z;
                break;
            case "No":
                Debug.Log("PP_Collicion");
                break;
            default:
                break;
        }

       
       
           
        


    }
}
