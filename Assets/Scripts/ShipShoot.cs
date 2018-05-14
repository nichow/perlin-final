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
	    var layerMask = 1 << 8;

        layerMask = ~layerMask;
		if (Input.GetButtonDown("Fire"))
		{
		    RaycastHit hit;
		    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 15f, layerMask))
		    {
		        Debug.Log("hit");
		    }
		    else
		    {
                Debug.Log("No Hit");
		    }
		}
	}
}
