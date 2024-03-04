using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool powered = false;
    public float maxAngle = 90f;
    public float offset = 0f;

    private float turnAngle;
    private WheelCollider wheel_collider;
    private Transform wheel_mesh;

    private void Start()
    {
        wheel_collider = GetComponent<WheelCollider>();
        wheel_mesh = transform.Find("wheel_mesh");
    }

    public void Steer(float steerInput)
    {
        turnAngle = steerInput * maxAngle + offset;
        wheel_collider.steerAngle = turnAngle;
    }

    public void Accelerate(float powerInput)
    {
        if(powered)
        {
            wheel_collider.motorTorque = powerInput;
        }
        else
        {
            wheel_collider.brakeTorque = 0;
        }
    }

    public void UpdatePosition()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        wheel_collider.GetWorldPose(out pos,out rot);
        wheel_mesh.transform.position = pos;
        wheel_mesh.transform.rotation = rot;
    }
}
