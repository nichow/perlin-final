using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject Player;
    private Vector3 _offset;


	// Use this for initialization
	void Start ()
	{
	    _offset = transform.position - Player.transform.position;
	}

    // LateUpdate is called once per frame, after any Update calls
    void LateUpdate()
    {
        var hdirection = Input.GetAxis("Horizontal"); // negative if left, positive if right
        var vdirection = Input.GetAxis("Vertical");   // negative if down, positive if up

        if (hdirection < 0)
        {
            transform.Rotate(-20 * Vector3.up * Time.deltaTime, Space.World);
            transform.Translate(7 * Vector3.left);
        }
        else if (hdirection > 0)
        {
            transform.Rotate(20 * Vector3.up * Time.deltaTime, Space.World);
            transform.Translate(7 * Vector3.right);
        }

//        if (vdirection > 0)
//        {
//            transform.Rotate(Vector3.left);
//        }
//        else if (vdirection < 0)
//        {
//            transform.Rotate(-1 * Vector3.left);
//        }

        //the camera's position is a set distance away from the player, modified by the z value of their velocity
        transform.position = (Player.transform.position + _offset) 
                             + new Vector3(0, 0, -.25f * Mathf.Clamp(Player.GetComponent<Rigidbody>().velocity.z, -.5f, .5f));
    }
}
