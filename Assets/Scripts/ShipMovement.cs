using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float _thrust;
    private Rigidbody _rb;
    private Renderer _rend;
    public Camera Camera;

    // Use this for initialization
    void Start ()
    {
        transform.rotation = Camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
