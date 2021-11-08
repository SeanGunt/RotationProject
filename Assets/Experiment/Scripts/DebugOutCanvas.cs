using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugOutCanvas : MonoBehaviour
{
    public static TextMeshProUGUI instance;
    // Start is called before the first frame update
    void Start()
    {
        if (DebugOutCanvas.instance == null)
        {
            instance = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
