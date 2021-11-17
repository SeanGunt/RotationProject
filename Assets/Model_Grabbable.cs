using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Model_Grabbable : XRGrabInteractable
{
    public static bool started;
    public static DateTime startTime;
    public static DateTime endTime;
    string filename;
    public static int playerId = 0;
    protected override void Awake()
    {
        base.Awake();
        startTime = DateTime.Now;
        if (!started)
        {
            started = true;
            playerId = PlayerPrefs.GetInt("player", 0);
            if (playerId != 0)
            {
                PlayerPrefs.SetInt("player", playerId++);
            }
        }

    }

    //protected override void OnSelectExiting(XRBaseInteractor interactor)
    //{
    //    Debug.Log("Object dropped " + RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct);
    //    File.AppendAllText(Application.dataPath.ToString() + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar + playerId + ".csv",
    //                playerId + "," +
    //               SceneManager.GetActiveScene().name + "," + RotationDetection.correct + "," +
    //                (DateTime.Now - startTime).TotalSeconds.ToString() + Environment.NewLine);
    // }
}



