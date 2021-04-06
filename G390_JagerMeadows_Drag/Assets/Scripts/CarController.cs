using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float acceleration;
    public float currentBrakeTorque;

    private Rigidbody rb;      //Reference to Rigidbody Component
    public float speed;        //Speed, updated through script
    


    private void Start()
    {
        // acceleration = acceleration * Time.deltaTime;   
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.forward * speed;
    }

    public void FixedUpdate()
    {

        
        //Set object velocity
        rb.velocity = -transform.forward * speed; 
        float motor = maxMotorTorque * Input.GetAxis("Gas") * acceleration * speed;
        if (Input.GetAxis("Gas") > 0)
        {
            speed += Time.deltaTime * acceleration;
            motor = maxMotorTorque * Input.GetAxis("Gas") * acceleration * speed;
        }
        if (Input.GetAxis("ReverseGas") > 0)
        {
            
            motor = maxMotorTorque * Input.GetAxis("ReverseGas") * -1f * speed;
        }
        if (Input.GetKey(KeyCode.JoystickButton1))
        {
            speed += Time.deltaTime * acceleration;
            currentBrakeTorque = 100000f;
        }
        else
        {
            speed = 5;
            currentBrakeTorque = 0f;
        }
        //float motor = maxMotorTorque * Input.GetAxis("Gas") * acceleration;
        //motor = maxMotorTorque * Input.GetAxis("ReverseGas");
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            if (axleInfo.hasBrakes)
            {
                axleInfo.leftWheel.brakeTorque = currentBrakeTorque;
                axleInfo.rightWheel.brakeTorque = currentBrakeTorque;
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
    public bool hasBrakes;
}