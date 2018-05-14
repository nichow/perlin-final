using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    public static List<Rigidbody> asteroids; //list of asteroids
                                             // Update is called once per frame

    public float startTime = 0.5f;
    public float spawnTick = 10.0f;
    public Rigidbody asteroid;
    public float minRadus;
    public float spawningRadius;
    public int limit;

    void Start()
    {
        minRadus = 1;
        spawningRadius = 10;
        limit = 3;
        count = 0;
        massRange = 20;
        massMin = 1;
        InvokeRepeating("CreateAsteroid", startTime, spawnTick);
    }


    void FixedUpdate()
    {
        removeFarAsteroids(Camera.main.gameObject.transform.position);
    }


    public static int count;

    public float massRange;
    public float massMin;
    void CreateAsteroid(Vector3 centerSpawningPoint)
    {
        if (count >= limit) return;
        count++;
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
        asteroidClone.mass = (Random.value * massRange) + massMin;
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
                count--;
                Destroy(r, 1);
            }
        }
    }

    void destoryAsteroid(Rigidbody a)
    {
        asteroids.Remove(a);
        count--;
        Destroy(a);
    }
}

