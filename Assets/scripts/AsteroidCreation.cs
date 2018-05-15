using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    public static List<Rigidbody> asteroids; //list of asteroids
                                             // Update is called once per frame
    public Camera cam;
    public float startTime = 0.5f;
    public float spawnTick = 10.0f;
    void Start()
    {
        InvokeRepeating("CreateAsteroid", startTime, spawnTick);
    }


    void FixedUpdate()
    {
        //removeFarAsteroids(Camera.main.gameObject.transform.position);
        removeFarAsteroids(cam.transform.position);
    }

    public Rigidbody asteroid;
    public float minRadus = 500;
    public float spawningRadius = 1000;
    public int limit = 30;

    int count = 0;

    public float massRange = 20;
    public float massMin = 1;

    void CreateAsteroid(float cameraLoc)
    {
        if (count >= limit) return;
        count++;
        if(asteroids == null)
        {
            asteroids = new List<Rigidbody>();
        }
        Vector3 spawnPos = new Vector3(Random.value * 10 - 5, Random.value * 5, cameraLoc + 20);
 
        //spawnPos += centerSpawningPoint;
        Rigidbody asteroidClone = (Rigidbody)Instantiate(asteroid, spawnPos, Random.rotation);
        asteroidClone.GetComponent<GravObject>().enabled = true;
        asteroidClone.mass = (Random.value * massRange) + massMin;
        asteroids.Add(asteroidClone);
    }

    void CreateAsteroid()
    {
        //Vector3 snd = new Vector3 (Camera.main.transform.position.x,Camera.main.transform.position.y, )
        CreateAsteroid(Camera.main.transform.position.z);
    }

    void removeFarAsteroids(Vector3 location)
    {
        if (asteroids == null) return;
        foreach (Rigidbody r in asteroids)
        {
            if(r.position.z < location.z)
            {
                asteroids.Remove(r);
                r.GetComponent<GravObject>().enabled = false;
                count--;
                Destroy(r.gameObject);
            }
        }
    }
}

