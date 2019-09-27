using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    int index = 0;

    void Start()
    {
        index = 0;
        transform.position = waypoints[0].transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].transform.position) < .1)
        {
            index++;
            if(index > waypoints.Length - 1)
            {
                System.Array.Reverse(waypoints);
                index = 1;
            }
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, 0.05f);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision");
        col.transform.parent = transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}

