using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCarController : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    public float turnSpeed;
   // Vector3 deltaRotation = (new Vector3(0, 100, 0) * Time.deltaTime);
   

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, turnSpeed, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -turnSpeed, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        
       // UpdateGameObjectAngle();
        
    }
    

    void UpdateGameObjectAngle()
    {

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 5f))
        {


            // rb.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            //Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -turnSpeed, 0) * Time.deltaTime);
            //Quaternion deltaRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            rb.MoveRotation(Quaternion.Euler(hitInfo.normal));
            print(hitInfo.normal);
            

        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down));
    }

   
}
