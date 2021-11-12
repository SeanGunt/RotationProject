using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Match the rotation of the target transform
/// </summary>
public class MatchRotation : MonoBehaviour
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

    [Tooltip("The transform this object will match")]
    public Transform targetTransform = null;
    private Vector3 originalRotation = Vector3.zero;

    private void Awake()
    {
        originalRotation = transform.eulerAngles;
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        if(scene.name == "RotationProject_Interval") {
            snapping = true;
        }
    }

    public void FollowRotation()
    {
        Vector3 newRotation = targetTransform.eulerAngles;
        newRotation.x = matchX ? newRotation.x : originalRotation.x;
        newRotation.y = matchY ? newRotation.y : originalRotation.y;
        newRotation.z = matchZ ? newRotation.z : (snapping ? Mathf.Round(newRotation.z/stepSize)*stepSize : originalRotation.z);
        // 15.5 = 15 
        // 40 / 15
        // 2.66
        // 3
        // 3 * 15 = 45
        //30 / 15
        //2
        //30
        //32 /15
        ///2.05
        // 2 (*15)
        // 30
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
