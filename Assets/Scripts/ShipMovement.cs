using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float _thrust;
    public Rigidbody rb;

    // Use this for initialization
    void Start ()
	{
	    _thrust = 50;
	}

    // Update is called once per frame
    void Update()
    {
        var hdirection = Input.GetAxis("Horizontal"); // negative if left, positive if right
        var vdirection = Input.GetAxis("Vertical");   // negative if down, positive if up

        if (hdirection < 0)
        {
            transform.Rotate(-1 * Vector3.forward);
        }
        else if (hdirection > 0)
        {
            transform.Rotate(Vector3.forward);
        }

        if (vdirection > 0)
        {
            transform.Rotate(Vector3.left);
        }
        else if (vdirection < 0)
        {
            transform.Rotate(-1 * Vector3.left);
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate ()
	{
	    var hdirection = Input.GetAxis("Horizontal"); // negative if left, positive if right
	    var vdirection = Input.GetAxis("Vertical");   // negative if down, positive if up
        if (Input.GetButton("Thrust"))
	    {
            rb.AddForce(transform.forward * _thrust * Time.fixedDeltaTime); //Accelerate
	    }
        else if (Input.GetButton("Brake"))
		{
		    rb.AddForce(-1 * transform.forward * _thrust * Time.fixedDeltaTime); //Decelerate
		}
        else if (rb.velocity.z > 0)
        {
            rb.AddForce(-1 * transform.forward * (_thrust / 4) * Time.fixedDeltaTime);
        }
	}
}
