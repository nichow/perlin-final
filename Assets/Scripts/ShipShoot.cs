using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShipShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //create layerMask just containing the player object
	    var layerMask = 1 << 8;
        //invert the mask so the player collider is ignored for purposes of ray creation
        layerMask = ~layerMask;
		if (Input.GetButtonDown("Fire"))
		{
		    var forward = transform.TransformDirection(Vector3.forward) * 15;
		    Debug.DrawRay(transform.position, forward, Color.green, 15, true);
            RaycastHit hit;
		    if (Physics.Raycast(transform.position, forward, out hit, 15f, layerMask))
		    {
		        if (hit.collider.gameObject.tag == "Asteroid")
		        {
                    Destroy(hit.collider.gameObject);
		        }
		        Debug.Log("hit");
		    }
		    else
		    {
                Debug.Log("No Hit");
		    }
		}
	}
}
