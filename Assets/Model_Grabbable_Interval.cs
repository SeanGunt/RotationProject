﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using System;
public class Model_Grabbable_Interval : XRGrabInteractable
{
    public float stepSize = 15f;
    public static bool snapping = true;

    [Tooltip("Match x rotation")]
    public bool matchX = false;

    [Tooltip("Match y rotation")]
    public bool matchY = false;

    [Tooltip("Match z rotation")]
    public bool matchZ = false;
    public static DateTime startTime;
    public static DateTime endTime;
    public static bool started;
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
            Debug.Log(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name != "RotationProject_Interval")
            {
                PlayerPrefs.SetInt("player", playerId + 1);
            }
        }

    }
    protected override void OnSelectExiting(XRBaseInteractor interactor)
     {
        Debug.Log("Object dropped " + RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct);
        File.AppendAllText(Application.dataPath.ToString() + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar + playerId + ".csv",
                    playerId + "," +
                 SceneManager.GetActiveScene().name + "," + RotationDetection.correct + "," +
                   (DateTime.Now - startTime).TotalSeconds.ToString() + Environment.NewLine);
     }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase arg)
    {
        base.ProcessInteractable(arg);
        if (arg == XRInteractionUpdateOrder.UpdatePhase.Fixed && selectingInteractor != null)
        {
            if (snapping == true)
            {
                Vector3 newRotation = selectingInteractor.transform.rotation.eulerAngles;
                newRotation.x = matchX ? Mathf.Round(newRotation.x / stepSize) * stepSize : newRotation.x;
                newRotation.y = matchY ? Mathf.Round(newRotation.y / stepSize) * stepSize : newRotation.y;
                newRotation.z = matchZ ? Mathf.Round(newRotation.z / stepSize) * stepSize : newRotation.z;
                transform.rotation = Quaternion.Euler(newRotation);
            }
            else
            {
                transform.rotation = selectingInteractor.transform.rotation;
            }
        }
    }
}
