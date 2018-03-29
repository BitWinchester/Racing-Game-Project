using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSuspension : MonoBehaviour {


    public GameObject wheelMesh;
    public float suspensionLength = 2f;
    RaycastHit hitInfo;
    private bool isGrounded;





    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        


        //Cast a ray into the world for the suspension
        Ray suspensionRay = new Ray(transform.position, gameObject.transform.up * -suspensionLength);
        Physics.Raycast(suspensionRay, out hitInfo);


        //Debug ray for testing 
        if (hitInfo.distance > suspensionLength)
        {
            isGrounded = false;
            Debug.DrawRay(transform.position, gameObject.transform.up * -suspensionLength, Color.red);
            hitInfo.point = gameObject.transform.up * -suspensionLength;
            wheelMesh.transform.position = gameObject.transform.position;

        }
        else
            isGrounded = true;
            Debug.DrawRay(transform.position, gameObject.transform.up * -suspensionLength, Color.green);
            wheelMesh.transform.position = hitInfo.point;



    }

    

    
}
