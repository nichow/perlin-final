using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour {
    public Transform head;
    public float speed;
	// Update is called once per frame
	void Update () {
        head.transform.rotation = Quaternion.Slerp(head.rotation, this.transform.rotation, Time.time * speed);
        head.transform.rotation *= Quaternion.Euler(0, -180f, 0);
        //Debug.Log("look here" + head.transform);
	}
}
