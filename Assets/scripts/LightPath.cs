using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour {
    private Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float sine = Mathf.Sin(Time.time*2) * 3;
        this.transform.position = startPos + new Vector3(0f, sine, 0f);
        //Debug.Log(sine);
	}
}
