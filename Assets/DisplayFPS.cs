using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFPS : MonoBehaviour
{

    public TextMeshProUGUI fpsText;

    private float timeP = 1f;
    private float time;
    private int countFrames;

    void Update()
    {
        time += Time.deltaTime;

        countFrames++;

        if (time >= timeP){
            int frameRate = Mathf.RoundToInt(countFrames / time);
            fpsText.text = frameRate.ToString() + " FPS";

            time -= timeP;
            countFrames = 0;
        }
        
    }
}
