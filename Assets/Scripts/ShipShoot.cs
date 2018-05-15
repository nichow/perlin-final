using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShipShoot : MonoBehaviour
{

    private LineRenderer _path;
    private Vector3[] _points;

	// Use this for initialization
	void Start ()
	{
	    _path = GetComponent<LineRenderer>();
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
		    var forward = transform.TransformDirection(Vector3.forward) * 50;
            var pathInit = Vector3.zero;
            _path.SetPosition(0, pathInit);
//		    Debug.DrawRay(transform.position, forward, Color.green, 15, true);
		    StartCoroutine(ShotEffect());
            RaycastHit hit;
		    if (Physics.Raycast(transform.position, forward, out hit, 50f, layerMask))
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
            _path.SetPosition(1, Vector3.zero + (Vector3.forward * 50));
        }
	}

    private IEnumerator ShotEffect()
    {
        _path.enabled = true;
        yield return new WaitForSeconds(.5f);
        _path.enabled = false;
    }
}
