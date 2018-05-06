using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float thrust;
    public Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
	    thrust = 50;
	}

    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate ()
	{
		if (Input.GetButton("Thrust"))
	    {
            rb.AddForce(transform.forward * thrust * Time.fixedDeltaTime); //Accelerate
	    }
        else if (Input.GetButton("Brake"))
		{
		    rb.AddForce(-1f * transform.forward * thrust * Time.fixedDeltaTime); //Decelerate
		}
	}
}
