using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationDetection : XRSocketInteractor
{
    public static bool hovered;
    public static bool correct;
    public override bool CanSelect(XRBaseInteractable args)
    {
        float angle = Quaternion.Angle(gameObject.transform.rotation, args.gameObject.transform.rotation);
        correct = angle < 15;
        return base.CanSelect(args) && angle < 15;
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
