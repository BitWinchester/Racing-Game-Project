﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSuspension2 : MonoBehaviour {

    private Rigidbody rb;
    public float wheelRadius;
    public GameObject wheelMesh;
    
    public float springConstant;
    public float damperConstant;
    public float restLength;
    public float tractionCoefficent;
    public float forwardSpeedLimit;

    public bool steeringWheels;

    private float previousLength;
    private float currentLength;
    private float springVelocity;
    private float springForce;
    private float damperForce;
    private bool isGrounded;

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    // STANDARD FUNCTIONS // 
    void Start () {
        rb = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, restLength + wheelRadius))
        {
            isGrounded = true;
            previousLength = currentLength;
            currentLength = restLength - (hit.distance - wheelRadius);
            springVelocity = (currentLength - previousLength) / Time.fixedDeltaTime;
            springForce = springConstant * currentLength;
            damperForce = damperConstant * springVelocity;
            //The orginal way to do this much more correct, added force up the local UP vector 
            rb.AddForceAtPosition(transform.up * (springForce + damperForce), transform.position);

            //Modified version for more control adds force up in world space, no loops im guessing but better ground control
            //rb.AddForceAtPosition(new Vector3(0,1,0) * (springForce + damperForce), transform.position);

            wheelMesh.transform.position = hit.point;
            SidewayVehicleSlip();
            ForwardSpeedLimiter();
        }
        else isGrounded = false;
    }

    //This adds a sideforce into the car if its not pointing in the same direction as the cars velocity is moving. 
    void SidewayVehicleSlip()
    {
        Vector3 sidewaysForce;
        float sidewaysPercentage;
        sidewaysPercentage = Mathf.Abs(Vector3.Dot(transform.right * -1f, rb.velocity.normalized));

        sidewaysForce = rb.transform.right * -1f * Vector3.Dot(transform.right, rb.velocity) * tractionCoefficent;

        if (sidewaysPercentage > 0.2)
        {
            rb.AddForce(sidewaysForce);
            //Debug.DrawRay(transform.position, sidewaysForce);


        }
      
    }

    void ForwardSpeedLimiter()
    {
        Vector3 forwardLimitingForce; 

        forwardLimitingForce = transform.forward * -1f * Vector3.Dot(transform.forward, rb.velocity) * forwardSpeedLimit;
        rb.AddForce(forwardLimitingForce);
    }



    // PHYSICS FUNCTIONS // 


    // AUDIO VISUAL FUNCTIONS //
}
