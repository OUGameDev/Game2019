using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].transform.position) < .1)
        {
            index = index + 1;
            if (index > waypoints.Length - 1)
            {
                System.Array.Reverse(waypoints);
                index = 1;
            }
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, 0.05f);    }
    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform;
    }
    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }

}
