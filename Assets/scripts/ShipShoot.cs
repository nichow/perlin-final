using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ShipShoot : MonoBehaviour {

    public LineRenderer laserLine;
    private Vector3 rayEnd;

    // Use this for initialization
    void Start() {
        rayEnd = new Vector3(0, 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        //create layerMask just containing the player object
        var layerMask = 1 << 8;
        //invert the mask so the player collider is ignored for purposes of ray creation
        layerMask = ~layerMask;
        if (Input.GetButtonDown("Fire"))
        {
            laserLine.SetPosition(1, transform.position + rayEnd);
            StartCoroutine(RayShot());
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 20f, layerMask))
            {
                laserLine.SetPosition(1, hit.point);
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

    IEnumerator RayShot()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(.5f);
        laserLine.enabled = false;
    }
}
