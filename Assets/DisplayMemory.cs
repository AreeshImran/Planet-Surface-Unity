using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMemory : MonoBehaviour
{
    public TextMeshProUGUI memoryDis;

    // Update is called once per frame
    void Update()
    {
        memoryDis.text = "Graphics Memory: " + SystemInfo.graphicsMemorySize + 
        "\nSystem Memory: " + SystemInfo.systemMemorySize ;
        
    }
}
