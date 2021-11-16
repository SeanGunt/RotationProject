using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
/// <summary>
/// Match the rotation of the target transform
/// </summary>
public class MatchRotation : XRGrabInteractable
{

    public float stepSize = 15f;
    public static bool snapping = false;
    // MatchRotation.snapping = true;
    [Tooltip("Match x rotation")]
    public bool matchX = false;

    [Tooltip("Match y rotation")]
    public bool matchY = false;

    [Tooltip("Match z rotation")]
    public bool matchZ = false;
    // private Vector3 originalRotation = Vector3.zero;

    private void Awake()
    {
        base.Awake();
        // originalRotation = transform.eulerAngles;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        if(scene.name == "RotationProject_Interval") 
        {
            snapping = true;
        }
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor) {
        Debug.Log("Is "+RotationDetection.hovered + " " + RotationDetection.correct);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase arg)
    {
        // Debug.Log(arg);
        base.ProcessInteractable(arg);
        if(arg==XRInteractionUpdateOrder.UpdatePhase.Fixed && selectingInteractor != null) {
            if (snapping) {
                Vector3 newRotation = selectingInteractor.transform.rotation.eulerAngles;
                newRotation.x = matchX ? Mathf.Round(newRotation.x/stepSize)*stepSize : newRotation.x;
                newRotation.y = matchY ? Mathf.Round(newRotation.y/stepSize)*stepSize : newRotation.y;
                newRotation.z = matchZ ? Mathf.Round(newRotation.z/stepSize)*stepSize : newRotation.z;
                transform.rotation = Quaternion.Euler(newRotation);
            } else {
                transform.rotation = selectingInteractor.transform.rotation;
            }
        }
    }
}
