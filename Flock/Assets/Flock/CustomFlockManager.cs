using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFlockManager : MonoBehaviour
{

    // supposed to be many prefabs
    public GameObject typoPrefab;
    public int numTypos = 281;
    public GameObject[] allTypos;
    public Vector3 limits = new Vector3(5, 5, 5);
    public Vector3 goalPos;

    [Header("Typo Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 15.0f)]
    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {
        allTypos = new GameObject[numTypos];
        for (int i = 0; i < numTypos; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-limits.x, limits.x),
                                                                Random.Range(-limits.y, limits.y),
                                                                Random.Range(-limits.z, limits.z));
            allTypos[i] = (GameObject)Instantiate(typoPrefab, pos, Quaternion.identity);
            allTypos[i].GetComponent<CustomFlock>().myManager = this;
        }
        goalPos = this.transform.position;

    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        if (Random.Range(0, 100) < 50)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-limits.x, limits.x),
                                                            Random.Range(-limits.y, limits.y),
                                                            Random.Range(-limits.z, limits.z));
        }
        */
        goalPos.y = Mathf.Sin(Time.time * 3f) * 0.15f;
        if (Time.realtimeSinceStartup > 10.0f)
        {
            goalPos.y = (Time.realtimeSinceStartup - 10.0f) * (Time.realtimeSinceStartup - 10.0f) * 0.2f + Mathf.Sin(Time.time * 3f) * 0.15f;
        }
        this.transform.position = goalPos;
    }
    
}