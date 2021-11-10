using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationDetection : XRSocketInteractor
{
    public GameObject comparison;
    public override bool CanSelect(XRBaseInteractable args)
    {
        float angle = Quaternion.Angle(comparison.transform.rotation, args.gameObject.transform.rotation);
        Debug.Log(angle);
        return base.CanSelect(args) && angle < 15;

    }
    void Start()
    {

    }
    void Update()
    {

    }
}
