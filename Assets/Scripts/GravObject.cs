using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Modified from: https://github.com/Brackeys/Gravity-Simulation-Tutorial/blob/master/Planet%20Gravity/Assets/Attractor.cs
 * Licence attached to that makes it public domain
 */

public class GravObject : MonoBehaviour
{
    const float G = 10f;

    public static List<GravObject> gravObjects;

    public Rigidbody rb;
	
	// Update is called once per given tick
	void FixedUpdate ()
    {
		foreach (GravObject g in gravObjects)
        {
            if(g != this)
            {
                ApplyForce(g);
            }
        }
	}

    void OnEnable()
    {
        if (gravObjects == null)
        {
            gravObjects = new List<GravObject>();
        }
        gravObjects.Add(this);
    }
    void OnDisable()
    {
        gravObjects.Remove(this);
    }
    void ApplyForce(GravObject other)
    {
        Rigidbody rbo = other.rb;
        Vector3 dir = rb.position - rbo.position;

        float r = dir.magnitude;
        if (r == 0f) return;

        float mag = (G * rb.mass * rbo.mass) / (r * r);

        Vector3 force = dir.normalized * mag;

        rbo.AddForce(force);
    }


}
