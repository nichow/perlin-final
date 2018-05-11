using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    public Rigidbody asteroid;
    public float spawningRadius = 1000;
    void CreateAsteroid()
    {
        Rigidbody asteroidClone = (Rigidbody)Instantiate(asteroid, Random.insideUnitSphere * spawningRadius, Random.rotation);
    }
}

