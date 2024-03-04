using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform gravityTarget;

    public float power = 15000f;
    public float torque = 500f;
    public float gravity = 9.81f;

    public bool autoOrient = false;
    public float autoOrientSpeed = 1.0f;

    private float horInput;
    private float verInput;
    private float steerAngle;

    public Wheel[] wheels;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ProcessInput();
        Vector3 diff = transform.position - gravityTarget.position;
        if(autoOrient)
        {
            AutoOrient(-diff);
        }
    }

    private void FixedUpdate()
    {
        ProcessForces();
        ProcessGravity();
    }

    private void ProcessInput()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }

    private void ProcessForces()
    {
        foreach(Wheel w in wheels)
        {
            w.Steer(horInput);
            w.Accelerate(verInput * power);
            w.UpdatePosition();
        }
    }

    private void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));
    }

    private void AutoOrient(Vector3 diff)
    {

    }
}
