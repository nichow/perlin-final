using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float _thrust;
    private Rigidbody _rb;
    private Renderer _rend;
    public Camera Camera;

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
        //position of object relative to the viewport (0, 0) is bottom left; (pixelWidth, pixelHeight) is top right
        var screenPos = Camera.WorldToScreenPoint(transform.position);

        if (hdirection < 0 && screenPos.x > 0)
        {
            transform.Translate(.2f * Vector3.left);
        }
        else if (hdirection > 0 && screenPos.x < Camera.pixelWidth)
        {
            transform.Translate(.2f * Vector3.right);
        }

        if (vdirection > 0 && screenPos.y < Camera.pixelHeight)
        {
            transform.Translate(.2f * Vector3.up);
        }
        else if (vdirection < 0 && screenPos.y > 0)
        {
            transform.Translate(.2f * Vector3.down);
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate ()
	{
        _rb.AddForce(Vector3.forward * _thrust * Time.fixedDeltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
