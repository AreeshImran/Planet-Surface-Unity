using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public float xFar;

    public float zFar;

    public float yOffset;

    public Transform centreofMap;

    public float rotationSpeed;
    public bool rotateClockwise;

    float timer = 0;

    void OrbitRotate(){
        if(rotateClockwise){
            float x = -Mathf.Cos(timer) * xFar;
            float z = Mathf.Sin(timer) * zFar;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centreofMap.position;
        }
        else{
            float x = Mathf.Cos(timer) * xFar;
            float z = Mathf.Sin(timer) * zFar;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centreofMap.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotationSpeed;
        OrbitRotate();
        transform.LookAt(centreofMap);
        
    }
}
