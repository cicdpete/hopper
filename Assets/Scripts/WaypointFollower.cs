using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currWaypoint = 0;

    [SerializeField] float speed = 1f;
    
    
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < .1f)
        {
            currWaypoint++;
            if (currWaypoint >= waypoints.Length)
                currWaypoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currWaypoint].transform.position, speed * Time.deltaTime);
    }
}
