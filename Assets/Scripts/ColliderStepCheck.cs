using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStepCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //OnCollisionEnter(Collision col){
    // foreach (ContactPoint cp in col.contacts){ if(cp.thisCollider == YourCollider)
    //{ if(cp.y < StepHeight && cp.y > yourCollider.bounds.min.y)
    //   { transform.position = Vector3.moveTowards(transform.position, cp.point, Time.deltaTime * yourSpeed); Rigidbody.velocity = transform.up;


    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
