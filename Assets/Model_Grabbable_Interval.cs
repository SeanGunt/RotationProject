using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
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

    private void Awake()
    {
        base.Awake();
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor) 
    {
        Debug.Log("Object dropped "+ RotationDetection.hovered + ", was successfully placed " + RotationDetection.correct);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase arg)
    {
        base.ProcessInteractable(arg);
        if(arg==XRInteractionUpdateOrder.UpdatePhase.Fixed && selectingInteractor != null) 
        {
            if (snapping == true) 
            {
                Vector3 newRotation = selectingInteractor.transform.rotation.eulerAngles;
                newRotation.x = matchX ? Mathf.Round(newRotation.x/stepSize) * stepSize : newRotation.x;
                newRotation.y = matchY ? Mathf.Round(newRotation.y/stepSize) * stepSize : newRotation.y;
                newRotation.z = matchZ ? Mathf.Round(newRotation.z/stepSize) * stepSize : newRotation.z;
                transform.rotation = Quaternion.Euler(newRotation);
            } 
            else 
            {
                transform.rotation = selectingInteractor.transform.rotation;
            }
        }
    }
}
