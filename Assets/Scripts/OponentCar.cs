using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentCar : MonoBehaviour
{
    [Header("Engine")]
    public float Movingspeed;
    public float TurningSpeed = 30f;
    public float BreakSpeed;
    [Header("Destination Var")]
    public Vector3 Destination;
    public bool DestinationReached;
    private void Update()
    {
        Drive();
    }
    public void Drive()
    {
        if(transform.position!=Destination)
        {
            Vector3 destinationdir=Destination-transform.position;
            destinationdir.y = 0;
            float destinationdistance = destinationdir.magnitude;
            if(destinationdistance>=BreakSpeed)
            {
                DestinationReached = false;
                Quaternion rotation = Quaternion.LookRotation(destinationdir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, TurningSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward*Movingspeed*Time.deltaTime);
            }
            else
            {
                DestinationReached = true;
            }
        }
    }
    public void LocateDestination(Vector3 Destination)
    {
        this.Destination = Destination;
        DestinationReached = false;
    }

}
