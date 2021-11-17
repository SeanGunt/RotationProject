using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using System.IO;


public class Model_Grabbable : XRGrabInteractable
{     
    public static DateTime startTime;
    public static DateTime endTime;
    protected override void Awake()
    {
        base.Awake();
        startTime = DateTime.Now;
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor) 
    {
        Debug.Log("Object dropped "+ RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct);
        if (RotationDetection.correct == true)
        {
            endTime = DateTime.Now;
            Debug.Log(endTime - startTime);
        }
    }

}
