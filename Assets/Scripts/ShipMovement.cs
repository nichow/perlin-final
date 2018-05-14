using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float _thrust;
    private Rigidbody _rb;

    // Use this for initialization
    void Start ()
	{
	    _thrust = 50;
	    _rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        var hdirection = Input.GetAxis("Horizontal"); // negative if left, positive if right
        var vdirection = Input.GetAxis("Vertical");   // negative if down, positive if up

        if (hdirection < 0)
        {
            transform.Translate(.2f * Vector3.left);
        }
        else if (hdirection > 0)
        {
            transform.Translate(.2f * Vector3.right);
        }

        if (vdirection > 0)
        {
            transform.Translate(.2f * Vector3.up);
        }
        else if (vdirection < 0)
        {
            transform.Translate(.2f * Vector3.down);
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate ()
	{
        _rb.AddForce(Vector3.forward * _thrust * Time.fixedDeltaTime);
	}
}
