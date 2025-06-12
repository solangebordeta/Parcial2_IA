using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    private float radius = 4;
    [SerializeField] LayerMask boids;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Flock()
    {
        Vector3 FlForce = Separation() + Cohesion() + alingtowards();
    }

    Vector3 Separation()
    {
        Vector3 dir = Vector3.zero; 
        int entities =0;
        float SeparationRad = 2;
        //separacion entre entidades

        var boidsinrange = Physics.OverlapSphere(transform.position, radius,boids);

        for (int i = 0; i < boidsinrange.Length, i++)
        {
            Flocking boids = boidsinrange[i].GetComponent< Flocking>();

            if (boids == null || boids == this) continue;

            dir += (this.transform.position - boids.transform.position).normalized / SeparationRad;
            entities++;
        }
        if (entities == 0) return Vector3.zero;
       
        dir /= entities;
        return dir;
    }

    Vector3 Cohesion() 
    {
        return
    }

    Vector3 alingtowards() 
    {
        return
    }
}
