using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SheepSteering : MonoBehaviour
{
    [Header("Parameters")]
    public float maxVelocity = 10f;
    public float timePrediction = 1f;
    public SteeringMode mode;

    [Header("References")]
    public Transform Playertarget;
    public Rigidbody PlayerRb;
    public GameObject Target;
    public ObstacleAvoidance obstacleAvoidance; //(Se arrastra el script desde el inspector)
    private ISteering currentSteering;
    public Rigidbody rb;
    private Vector3 finalForce;

    [SerializeField] Boid boid;

    Flee flee;
    Flock flock;
    None none;
    Seek seek;

    public enum SteeringMode
    {
        flee,
        follow,
        None,
        move,
    }

    void Start()
    {
        seek = new(this.rb, null, 10);
        flee = new(Target, maxVelocity);
        currentSteering = none;
    }

    public void changeDirection(Transform newtarget)
    {
        seek.target = newtarget;
    }


    public void ExecuteSteering() //ejecuta la logica del comportamiento
    {

        Vector3 steeringDir = currentSteering.MoveDirection();

        //dirección de evasión de obstáculos
        Vector3 avoidDir = obstacleAvoidance ? obstacleAvoidance.Avoid() : Vector3.zero;

        //suma de ambas fuerzas
        finalForce = steeringDir + avoidDir + boid.Flocking();

        if (steeringDir != Vector3.zero)
        {
            //aplicación de la fuerza al Rigidbody
            rb.AddForce(finalForce, ForceMode.Acceleration);

            //rotación hacia la dirección de movimiento
            if (rb.velocity != Vector3.zero)
                transform.forward = rb.velocity.normalized;
        }
    }

    public void ChangeStearingMode(SteeringMode mode) //cambia el comportamiento segun el modo
    {
        this.mode = mode;

        switch (mode)
        {

            case SteeringMode.flee:
                currentSteering = flee;
                break;
            case SteeringMode.follow:
       
                currentSteering = flock;
                break;
            case SteeringMode.move:
                currentSteering = seek;
                break;
            case SteeringMode.None: 
                currentSteering = null; break;
        }
    }
}
