using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationDetection : XRSocketInteractor
{
    public GameObject comparison;
    public static bool hovered;
    public static bool correct;
    void start()
    {
        Debug.Log("Start");
    }
    public override bool CanSelect(XRBaseInteractable args)
    {
        float angle = Quaternion.Angle(gameObject.transform.rotation, args.gameObject.transform.rotation);
        // Debug.Log(correct + angle.ToString());
        correct = angle < 15;
        return base.CanSelect(args) && angle < 15;
    }

    public void WasCorrect()
    {
        // Debug.Log("Object dropped " + RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct);
        // File.AppendAllText(Application.dataPath.ToString() + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar + Model_Grabbable.playerId + ".csv",
        //             Model_Grabbable.playerId + "," +
        //            SceneManager.GetActiveScene().name + "," + true + "," +
        //            (DateTime.Now - Model_Grabbable.startTime).TotalSeconds.ToString() + Environment.NewLine);
    }

    public void myHoverEnter(HoverEnterEventArgs arg)
    {
        hovered = true;
    }
    public void myHoverExit(HoverExitEventArgs arg)
    {
        hovered = false;
    }
}
