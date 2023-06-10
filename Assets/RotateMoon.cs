using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    public float speedofRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speedofRotation, 0)* Time.deltaTime);
        
    }
}
