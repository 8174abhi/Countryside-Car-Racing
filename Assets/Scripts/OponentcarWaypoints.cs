using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentcarWaypoints : MonoBehaviour
{

    [Header("Oponent Car")]
    public OponentCar oponentCar;
    public Waypoint currentWaypoint;
    private void Awake()
    {
        oponentCar = GetComponent<OponentCar>();
    }
    private void Start()
    {
        oponentCar.LocateDestination(currentWaypoint.Getpositision());
    }
    private void Update()
    {
        if(oponentCar.DestinationReached)
        {
            currentWaypoint = currentWaypoint.NextWaypoint;
            oponentCar.LocateDestination(currentWaypoint.Getpositision());
        }
    }
}
