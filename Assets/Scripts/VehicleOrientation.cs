using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleOrientation : MonoBehaviour {

    public Rigidbody rb;
    Quaternion previousRotation;
    Quaternion currentRotation;
    public float rotSpeed = 0.1f;



    void Update () {
        
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2.5f))
        {

            previousRotation = rb.rotation;
            //rb.MoveRotation(Quaternion.FromToRotation(transform.up, hitInfo.normal) * rb.rotation);
            currentRotation = Quaternion.FromToRotation(transform.up, hitInfo.normal) * rb.rotation;
            rb.MoveRotation(Quaternion.Slerp(previousRotation, currentRotation, Time.deltaTime * rotSpeed));
        }
        Debug.DrawRay(transform.position, Vector3.down);

       
    }
}
