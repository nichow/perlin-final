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
		    RaycastHit hit;
		    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 15f, layerMask))
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
