using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    public static List<Rigidbody> asteroids;
    // Update is called once per frame
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
           
    }

    public Rigidbody asteroid;
    public float spawningRadius = 1000;
    void CreateAsteroid(Vector3 centerSpawningPoint)
    {
        if(asteroids == null)
        {
            asteroids = new List<Rigidbody>();
        }
        Rigidbody asteroidClone = (Rigidbody)Instantiate(asteroid, (Random.insideUnitSphere * spawningRadius) + centerSpawningPoint, Random.rotation);
        asteroidClone.GetComponent<GravObject>().enabled = true;
        asteroids.Add(asteroidClone);
    }

    void removeFarAsteroids(Vector3 location)
    {
        foreach (Rigidbody r in asteroids)
        {
            if((r.position - location).magnitude > spawningRadius)
            {
                asteroids.Remove(r);
                Destroy(r, 1);
            }
        }
    }
}

