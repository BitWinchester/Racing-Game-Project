using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCenterOfGravity : MonoBehaviour {
    public Vector3 centerOfMass;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
