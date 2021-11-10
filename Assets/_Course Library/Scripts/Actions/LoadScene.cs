using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene using name, or reload the active scene
/// </summary>
public class LoadScene : MonoBehaviour
{
    public void LoadSceneUsingName(string RotationProject_Interval)
    {
        SceneManager.LoadScene(RotationProject_Interval);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
