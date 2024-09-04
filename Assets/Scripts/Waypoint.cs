using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("WayPoint Status")]
    public Waypoint PreviousWaypoint;
    public Waypoint NextWaypoint;
    [Range(0f, 5f)]
    public float WaypointWidth = 1f;
    public Vector3 Getpositision()
    {
        Vector3 Minbound = transform.position + transform.right * WaypointWidth / 2f;
        Vector3 Maxbound = transform.position - transform.right * WaypointWidth / 2f;
        return Vector3.Lerp(Minbound, Maxbound, Random.Range(0f, 1f));

    }
}
