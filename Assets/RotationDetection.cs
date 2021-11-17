using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationDetection : XRSocketInteractor
{
    public GameObject comparison;
    public static bool hovered;
    public static bool correct;
    void start() {
        Debug.Log("Start");
    }
    public override bool CanSelect(XRBaseInteractable args)
    {
        float angle = Quaternion.Angle(comparison.transform.rotation, args.gameObject.transform.rotation);
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
