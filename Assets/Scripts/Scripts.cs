using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{

    [Header("Wheel Colider")]
    public WheelCollider FrontLeftWheel;
    public WheelCollider FrontRightWheel;
    public WheelCollider RiverseRightWheel;
    public WheelCollider RiverseLeftWheel;
    [Header("sound")]
    public AudioSource auodiosource;
    public AudioClip acelatorsound;
    public AudioClip slowacceliration;
    public AudioClip stopsound;
    [Header("Wheels Transform")]
    public Transform fr;
    public Transform fl;
    public Transform rl;
    public Transform rr;
    [Header("Car Engine")]
    public float Acceleration;
    public float breakforce = 3000f;
    public float presentAcceliration;
     float presentbreakforce;
    [Header("Car Steering")]
    public float Wheeltorgue = 35f;
    public float preseturnangle = 0f;
    private void Update()
    {
        MoveCar();
        Steering();
        //Brakes();
    }
    void MoveCar()
    {
        if(presentAcceliration>0)
        {
            auodiosource.PlayOneShot(acelatorsound, 0.2f);

        }
        else if(presentbreakforce<0) 
        {
            auodiosource.PlayOneShot(slowacceliration, .2f);
        }
        else if (presentAcceliration==0)
        {
            auodiosource.PlayOneShot(stopsound, .1f);
        }
        
        FrontLeftWheel.motorTorque = presentAcceliration;
        FrontRightWheel.motorTorque = presentAcceliration;
        RiverseLeftWheel.motorTorque = presentAcceliration;
        RiverseRightWheel.motorTorque = presentAcceliration;
        presentAcceliration = Acceleration * SimpleInput.GetAxis("Vertical");
    }
    void Steering()
    {
        
        preseturnangle = Wheeltorgue * SimpleInput.GetAxis("Horizontal");
        FrontLeftWheel.steerAngle = preseturnangle;
        FrontRightWheel.steerAngle = preseturnangle;
        SteringWheel(FrontLeftWheel, fl);
        SteringWheel(FrontRightWheel, fr);
        SteringWheel(RiverseLeftWheel, rl);
        SteringWheel(RiverseRightWheel, rr);
    }
    void SteringWheel(WheelCollider WC,Transform WT )
    {
        Vector3 position;
        Quaternion Rotation;
        WC.GetWorldPose(out position, out Rotation);
        WT.rotation = Rotation;
        WT.position = position;

    }
  public  void Brakes()
    {
        StartCoroutine(CarBrakes());
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    presentbreakforce = breakforce;
        //    Debug.Log("brakes ");
        //}

        //else
        //{

        //    presentbreakforce = 0f;
        //}
        
    }
    IEnumerator CarBrakes()
    {
        presentbreakforce = breakforce;
        FrontLeftWheel.brakeTorque = presentbreakforce;
        FrontRightWheel.brakeTorque = presentbreakforce;
        RiverseLeftWheel.brakeTorque = presentbreakforce;
        RiverseRightWheel.brakeTorque = presentbreakforce;
        yield return new WaitForSeconds(2f);
        presentbreakforce = 0f;
        FrontLeftWheel.brakeTorque = presentbreakforce;
        FrontRightWheel.brakeTorque = presentbreakforce;
        RiverseLeftWheel.brakeTorque = presentbreakforce;
        RiverseRightWheel.brakeTorque = presentbreakforce;

    }




}
