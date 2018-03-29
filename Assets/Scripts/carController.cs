using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    public float turnSpeed;
    [HideInInspector]
    public RaceManager raceManger;

    private VehicleSuspension2 vehicleSupspension;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        vehicleSupspension = GetComponentInChildren<VehicleSuspension2>();
        raceManger = FindObjectOfType<RaceManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {



        if (vehicleSupspension.IsGrounded == true && raceManger.IsRacingStarted && raceManger.IsRaceFinished == false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(transform.forward * -speed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(transform.up * turnSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(transform.up * -turnSpeed);
            }
        }

    }
}
