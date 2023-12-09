using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    
    private void Update()
        //set the position of moving plattform 
    {
        // check the distance between platform and currently active waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f )
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            { 
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
