using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntervalRotation : XRDirectInteractor
{
    private XRBaseInteractable interactable;
    public bool isGrabbed = false;

    // Use this for initialization
    void Start()
    {
        interactable = this.GetComponent<XRBaseInteractable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (interactable != null && interactable.attachedToHand != null)
        {

            isGrabbed = true;
            Debug.Log(isGrabbed);
        }

    }
}
