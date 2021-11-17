using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TimerSelect : MonoBehaviour
{
    public void StopTimer()
    {
        Debug.Log("Stopped timer");
        Debug.Log(Application.dataPath.ToString() + "output.csv");
        File.AppendAllText(Application.dataPath.ToString() + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar + "output.csv",
                   ("Object dropped " + RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct) + "," +
                   (Model_Grabbable.endTime - Model_Grabbable.startTime).TotalSeconds.ToString() + Environment.NewLine);
    }
}