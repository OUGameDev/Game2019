using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovingPlatform : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;

    public float moveSpeed = 1;
    private GameObject target = null;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        target = null;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(Mathf.Sin(Time.time) * moveSpeed));
    }

    void OnTriggerEnter(Collider col)
    {
        col.transform.parent = transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }

}
