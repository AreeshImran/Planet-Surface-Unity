using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float xInput, zInput;
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        if (xInput != 0){
            rotateCam();
        }

        if (zInput != 0){
            navigateCam();
        }


        void rotateCam(){
            transform.Rotate(new Vector3(0f, xInput * Time.deltaTime, 0f));
        }

        void navigateCam(){
            transform.position += transform.forward * zInput * Time.deltaTime;
        }
    }
}
