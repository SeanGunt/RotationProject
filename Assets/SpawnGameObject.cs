using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public static SpawnGameObject instance;
    public GameObject trigger;
    public static Vector3 spawnPositionOffset = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTrigger()
    {
        spawnPositionOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        GameObject.Instantiate(trigger, transform.position + spawnPositionOffset, Quaternion.identity);
    }
}
