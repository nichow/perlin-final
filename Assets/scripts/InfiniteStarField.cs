using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStarField : MonoBehaviour
{
    private Transform tx;//transform position of camera
    private ParticleSystem.Particle[] points; // array of particles
    public int starsMax = 100;
    public float starSz = 1;
    public float starDist = 10;
    public float starClipDist = 1;
    public float starDistSqr;
    public float starClipDistSqr;


    // Use this for initialization
    void Start()
    {
        tx = transform;
       // starDistSqr = Mathf.Pow(starDist, 2);
        /*   starClipDistSqr = Mathf.Pow(starClipDist, 2);*/
    }

    private void StarsInit() // create each particle(start)
    {
        points = new ParticleSystem.Particle[starsMax];//initiate points array type particle system
        for (int i = 0; i < starsMax; i++)
        {
            //create random position within a sphere of radius one, then multiply by the star square distance + the camera position 
            points[i].position = Random.insideUnitSphere * starDist + tx.position;//will keep particles around the camera(tx.position)
            points[i].color = Color.white; //white color 
            points[i].size = starSz;//particle size 
                                    /*   if ((points[i].position - tx.position).sqrMagnitude > starDistSqr)
                                       {
                                           //if the position of the particle - the camera position's square magnitude is larger than the star squared distance 
                                           points[i].position = Random.insideUnitSphere.normalized * starDistSqr + tx.position;
                                           //change the position by multiplying a random point within a sphere of radius 1 + camera position    
                                       }

                                       if((points[i].position - tx.position).sqrMagnitude <= starClipDistSqr)
                                       {
                                           //if the particle position - camera position <= the star clip distance squared
                                           float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistSqr;
                                           points[i].color = Color.white;
                                           points[i].size = percent * starSz;
                                       }*/
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (points == null) StarsInit(); // create particles

        //for(int i=0; i < starsMax; i ++)
        //  {
        //check each particle and its distance between the camera and itself
        // if((points[i].position - tx.position).sqrMagnitude > starDistSqr){
        //if the position of the star is too far away
        // points[i].position = tx.position;
        //      Random.insideUnitSphere * starDist + tx.position;
        // }
        //    }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

        //}

    }

}
