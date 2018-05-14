using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    public static List<Rigidbody> asteroids; //list of asteroids
    // Update is called once per frame
    
    void Update()
    {
        
    }

    public int spawnOnTick = 500;
    int tick = 0;

    void FixedUpdate()
    {
        removeFarAsteroids(Camera.main.gameObject.transform.position);
        if (tick % spawnOnTick == 0)
        {
            CreateAsteroid(Camera.main.gameObject.transform.position);
            tick = 0;
        }
        else
        {
            tick++;
        }
    }

    public Rigidbody asteroid;
    public float minRadus = 500;
    public float spawningRadius = 1000;
    void CreateAsteroid(Vector3 centerSpawningPoint)
    {
        if(asteroids == null)
        {
            asteroids = new List<Rigidbody>();
        }
        Vector3 spawnPos = Random.insideUnitSphere * spawningRadius;
        bool isValid = false;
        while (!isValid)
        {
            if(spawnPos.magnitude > minRadus)
            {
                isValid = true;
            }
            else
            {
                spawnPos = Random.insideUnitSphere * spawningRadius;
            }
        }
        spawnPos += centerSpawningPoint;
        Rigidbody asteroidClone = (Rigidbody)Instantiate(asteroid, (Random.insideUnitSphere * spawningRadius) + centerSpawningPoint, Random.rotation);
        asteroidClone.GetComponent<GravObject>().enabled = true;
        asteroids.Add(asteroidClone);
    }

    void removeFarAsteroids(Vector3 location)
    {
        if (asteroids == null) return;
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

