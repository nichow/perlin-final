using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float _thrust;
    private Rigidbody _rb;
    public Camera cam;

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

        transform.eulerAngles = cam.transform.eulerAngles;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
