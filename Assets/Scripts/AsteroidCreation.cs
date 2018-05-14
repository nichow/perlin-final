using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    public static List<Rigidbody> asteroids; //list of asteroids
                                             // Update is called once per frame

    public float startTime = 0.5f;
    public float spawnTick = 10.0f;
    void Start()
    {
        InvokeRepeating("CreateAsteroid", startTime, spawnTick);
    }


    void FixedUpdate()
    {
        removeFarAsteroids(Camera.main.gameObject.transform.position);
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

    void CreateAsteroid()
    {
        CreateAsteroid(Camera.main.transform.position);
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

