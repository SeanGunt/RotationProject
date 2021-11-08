using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TimerSelect : MonoBehaviour
{
    DateTime startTime;
    public TextMeshProUGUI output;
    public static int trial = 0;
    public static int numTrials = 5;
    public static bool triggerActive = false;
    // Start is called before the first frame update
    void Start()
    {
        triggerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime != null)
        {
            DebugOutCanvas.instance.text = (startTime - DateTime.Now).ToString();
        }
    }

    public void StopTimer()
    {
        Debug.Log("Stopped timer");
        Debug.Log(Application.dataPath.ToString() + "output.csv");
        File.AppendAllText(Application.dataPath.ToString() + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar + "output.csv",
                   trial + "," + (DateTime.Now - startTime).TotalSeconds.ToString() + Environment.NewLine);
        trial += 1;
        if (trial < numTrials)
        {
            SpawnGameObject.instance.SpawnTrigger();
        }
        else
        {
            Debug.Log("Done");
        }
    }

    public void Awake()
    {
        Debug.Log("Strating timer...");
        startTime = DateTime.Now;
    }
}
