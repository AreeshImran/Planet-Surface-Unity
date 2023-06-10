using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    
    public float point = 10f;

    public float startSpeed = 5f;

    public Vector3 posStart;

    void Start()
    {
        posStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = posStart;

        v.y += point * Mathf.Sin(Time.time * startSpeed);
        transform.position = v;
        
    }
}
