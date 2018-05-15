using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Drop : MonoBehaviour {
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {	
            this.transform.position = startPos - new Vector3(0f, Time.time/2, 0f);
        //Debug.Log(this.transform.position);
	}
}
