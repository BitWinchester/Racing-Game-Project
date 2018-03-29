﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackCar : MonoBehaviour {
    public GameObject car;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - car.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = car.transform.position + offset;
	}
}
