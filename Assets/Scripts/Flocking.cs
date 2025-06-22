using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    private float radius = 4;
    [SerializeField] LayerMask boids;
    [SerializeField] Flock SteeringFlock;
    // Start is called before the first frame update

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

        for (int i = 0; i < boidsinrange.Length; i++)
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
        int entities = 0;
        Vector3 Center = Vector3.zero;

        var boidsinrange = Physics.OverlapSphere(transform.position, radius, boids);
        for (int i = 0; i < boidsinrange.Length; i++)
        {
            Flocking boids = boidsinrange[i].GetComponent<Flocking>();

            if (boids == null || boids == this) continue;

            Center += boids.transform.position;
            entities++; 
        }
            if (entities == 0) return Center;

            Center /= entities;

        return SteeringFlock.MoveDirection();
    }

    Vector3 alingtowards() 
    {
        //int count = 0;
        //Vector3 desired = Vector3.zero;
        //var boidsInRange = Physics.OverlapSphere(transform.position, viewRadius, boids);
        //for (int i = 0; i < boidsInRange.Length; i++)
        //{
        //    Boid boid = boidsInRange[i].GetComponent<Boid>();
        //    if (boid == null || boid == this) continue;
        //    desired += boid.Velocity;
        //    count++;
        //}
        //if (count == 0) return desired;
        //desired /= count;
        return Vector3.zero;
            //CalculateSteering(desired.normalized * _maxSpeed);
    }
}
